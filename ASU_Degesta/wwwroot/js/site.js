// Write your JavaScript code.

var toggler = document.getElementsByClassName("caret");
var i;

for (i = 0; i < toggler.length; i++) {
    toggler[i].addEventListener("click", function () {
        this.parentElement.querySelector(".nested").classList.toggle("active");
        this.classList.toggle("caret-down");
    });
}

function SendAjax(data, url, isAsync, type, dataType = 'json') {
    var result = {}

    $.ajax({
        url: url,
        data: JSON.stringify(data),
        type: type,
        dataType: dataType,
        async: isAsync,
        contentType: 'application/json; charset=utf-8',
        xhrFields: {
            'responseType': 'blob'
        },
        error: function (jqXHR, exception) {

            if (jqXHR.status === 0) {
                alert('Not connect. Verify Network.');
                return;
            } else if (jqXHR.status == 404) {
                alert('Requested page not found (404).');
                return;
            } else if (jqXHR.status == 500) {
                alert('Internal Server Error (500).');
                return;
            } else if (exception === 'parsererror') {
                alert('Requested JSON parse failed.');
                return;
            } else if (exception === 'timeout') {
                alert('Time out error.');
                return;
            } else if (exception === 'abort') {
                alert('Ajax request aborted.');
                return;
            } else {
                alert('Uncaught Error. ' + jqXHR.responseText);
                return;
            }
        }
    }).done(function (response) {
        result = response;
    });
    return result;
}

function SendAjaxAsync(data, url, type, dataType = 'json') {

    return new Promise(function (resolve, reject) {
        $.ajax({
            url: url,
            data: JSON.stringify(data),
            type: type,
            dataType: dataType,
            async: true,
            contentType: "application/json",
            error: function (jqXHR, exception) {

                if (jqXHR.status === 0) {
                    alert('Not connect. Verify Network.');
                } else if (jqXHR.status == 404) {
                    alert('Requested page not found (404).');
                } else if (jqXHR.status == 500) {
                    alert('Internal Server Error (500).');
                } else if (exception === 'parsererror') {
                    alert('Requested JSON parse failed.');
                } else if (exception === 'timeout') {
                    alert('Time out error.');
                } else if (exception === 'abort') {
                    alert('Ajax request aborted.');
                } else {
                    alert('Uncaught Error. ' + jqXHR.responseText);
                }
                resolve(false);
            }
        }).done(function (response) {
            resolve(response);
        })
    });
}

function GetFile(url, data, info) {
    $.ajax({
        type: 'POST',
        headers: {"RequestVerificationToken": $('input[name="__RequestVerificationToken"]').val()},
        url: '/api/' + url,
        data: JSON.stringify(data),
        contentType: 'application/json; charset=utf-8',
        dataType: 'binary',
        xhrFields: {
            'responseType': 'blob'
        },
        error: function (jqXHR, exception) {
            if (jqXHR.status === 0) {
                alert('Not connect. Verify Network.');
            } else if (jqXHR.status == 404) {
                alert('Requested page not found (404).');
            } else if (jqXHR.status == 500) {
                alert('Internal Server Error (500).');
            } else if (exception === 'parsererror') {
                alert('Requested JSON parse failed.');
            } else if (exception === 'timeout') {
                alert('Time out error.');
            } else if (exception === 'abort') {
                alert('Ajax request aborted.');
            } else {
                alert('Uncaught Error. ' + jqXHR.responseText);
            }
            $("#loading").hide();
        }
    }).done(function (result) {
        var blob = new Blob([result]);
        var link = document.createElement('a');
        link.href = window.URL.createObjectURL(blob);
        link.download = info['filename'] + '_' + info['file_id'] + '.docx';
        link.click();
        $("#loading").hide();
    });
}

function uuidv4() {
    return ([1e7] + -1e3 + -4e3 + -8e3 + -1e11).replace(/[018]/g, c =>
        (c ^ crypto.getRandomValues(new Uint8Array(1))[0] & 15 >> c / 4).toString(16)
    );
}

function checkCookies() {
    let cookieDate = localStorage.getItem('cookieDate');
    let cookieNotification = document.getElementById('cookie_notification');
    let cookieBtn = cookieNotification.querySelector('.cookie_accept');

    if (!cookieDate || (+cookieDate + 31536000000) < Date.now()) {
        cookieNotification.classList.add('show');
    }

    cookieBtn.addEventListener('click', function () {
        localStorage.setItem('cookieDate', Date.now());
        cookieNotification.classList.remove('show');
    })
}

checkCookies();

function pasteName(text) {
    var elem = document.getElementById("paste");
    elem.value = text;
}

function openUrlOption(obj, url) {
    var selectBox = obj;
    var selectedValue = selectBox.options[selectBox.selectedIndex].value;
    window.open('../../' + url + selectedValue);
}   
