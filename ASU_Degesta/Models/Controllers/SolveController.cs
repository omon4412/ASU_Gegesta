using Google.OrTools.LinearSolver;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace ASU_Degesta.Models.Controllers;

[AllowAnonymous]
[ApiController]
[Route("api/SolveTheTask")]
public class SolveController : Controller
{
    [AllowAnonymous]
    public string OnPost([FromBody] Data dataFromFront)
    {
        JArray json = JArray.Parse(dataFromFront.json);

        //bool isInteger = json[json.Count - 1][0].ToObject<bool>();
        //int maxmin = json[json.Count - 1][1].ToObject<int>();
        int length = json[0].Count() - 1;

        //json.RemoveAt(json.Count - 1);

        List<double> target = json[json.Count - 1].ToObject<List<double>>();
        target.Insert(0, 0);

        json.RemoveAt(json.Count - 1);

        List<double> limit = json[json.Count - 1].ToObject<List<double>>();
        //limit.Insert(0,0);
        json.RemoveAt(json.Count - 1);
        List<List<double>> limits = new List<List<double>>();

        for (int i = 0; i < length; i++)
        {
            var temp = new List<double>();
            for (int j = 0; j < length; j++)
            {
                temp.Add(0);
            }

            limits.Add(temp);
        }

        for (int i = 0; i < length; i++)
        {
            limits[i][i] = 1;
            limits[i].Insert(0, limit[i]);
        }


        List<List<double>> data = json.ToObject<List<List<double>>>();

        foreach (var array in data)
        {
            array.Insert(0, array[array.Count - 1]);
            array.RemoveAt(array.Count - 1);
        }

        foreach (var item in limits)
        {
            data.Add(item);
        }

        data.Add(target);
        Solver solver = Solver.CreateSolver("SCIP"); // Создание объекта "решателя"

        var vars = new List<Variable>(); // Создание переменных

        for (int i = 0; i < data[0].Count - 1; i++) // Цикл инициализации переменных
        {
            vars.Add(solver.MakeIntVar(0, Double.MaxValue, "x_" + i + 1));
        }


        for (int i = 0; i < data.Count - 1; i++) // Цикл создания и инициализации ограничений
        {
            Constraint ct = solver.MakeConstraint(0.0, data[i][0], "ct_" + i);
            for (int j = 1; j < data[i].Count; j++)
            {
                ct.SetCoefficient(vars[j - 1], data[i][j]);
            }
        }

        Objective objective = solver.Objective(); // Создание объекта целевой функции
        for (int i = 1; i < data[data.Count - 1].Count; i++)
        {
            objective.SetCoefficient(vars[i - 1],
                data[data.Count - 1][i]); // Цикл записи коеффициентов в целевую функцию
        }

        objective.SetMaximization(); // Поиск максимального значения

        Solver.ResultStatus resultStatus = solver.Solve(); // Решение и результат

        List<double> results = new List<double>(); // Список для результатов
        foreach (var item in vars)
        {
            results.Add(item.SolutionValue()); // Цикл внесения значений переменных в список
        }

        results.Add(solver.Objective().Value()); // Внесение значения целевой функции
        JArray result = new JArray(results);


        var jsonObject = new JArray(result.ToString());

        return result.ToString();
    }
}

public class Data
{
    public string json { get; set; }
}