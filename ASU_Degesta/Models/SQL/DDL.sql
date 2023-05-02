create table asu_degesta.equipments
(
    EquipmentId   int auto_increment
        primary key,
    EquipmentName longtext not null
);

create table asu_degesta.forecastmaximumdemandproducts_id
(
    doc_id        varchar(255) not null
        primary key,
    doc_name      longtext     not null,
    creation_date longtext     not null,
    creator       longtext     not null
);

create table asu_degesta.monthlyproductreleaseplan_id
(
    doc_id        varchar(255) not null
        primary key,
    doc_name      longtext     not null,
    creation_date longtext     not null,
    creator       longtext     not null
);

create table asu_degesta.payroll_statement_name_id
(
    doc_id        varchar(255) not null
        primary key,
    doc_name      longtext     not null,
    creation_date longtext     not null,
    creator       longtext     not null
);

create table asu_degesta.payroll_statement
(
    id              int auto_increment
        primary key,
    doc_id          varchar(50) not null,
    employee_number int         not null,
    employee_name   longtext    not null,
    salary          double      not null,
    bonus           longtext    not null,
    total_accrued   longtext    not null,
    withheld        longtext    not null,
    to_issue        longtext    not null,
    constraint FK_payroll_statement_payroll_statement_name_id_doc_id
        foreign key (doc_id) references asu_degesta.payroll_statement_name_id (doc_id)
            on delete cascade
);

create table asu_degesta.pricelist_id
(
    doc_id        varchar(255) not null
        primary key,
    doc_name      longtext     not null,
    creation_date longtext     not null,
    creator       longtext     not null
);

create table asu_degesta.reportavailableequipmentperformance_id
(
    doc_id        varchar(255) not null
        primary key,
    doc_name      longtext     not null,
    creation_date longtext     not null,
    creator       longtext     not null
);

create table asu_degesta.reportcostsproductioncapacity_id
(
    doc_id        varchar(255) not null
        primary key,
    doc_name      longtext     not null,
    creation_date longtext     not null,
    creator       longtext     not null
);

create table asu_degesta.reportmatherialcosts_id
(
    doc_id        varchar(255) not null
        primary key,
    doc_name      longtext     not null,
    creation_date longtext     not null,
    creator       longtext     not null
);

create table asu_degesta.reportproductcost_id
(
    doc_id        varchar(255) not null
        primary key,
    doc_name      longtext     not null,
    creation_date longtext     not null,
    creator       longtext     not null
);

create table asu_degesta.reportproductplan_id
(
    doc_id        varchar(255) not null
        primary key,
    doc_name      longtext     not null,
    creation_date longtext     not null,
    creator       longtext     not null
);

create table asu_degesta.specificationcontractmaterials_id
(
    doc_id        varchar(255) not null
        primary key,
    doc_name      longtext     not null,
    creation_date longtext     not null,
    creator       longtext     not null
);

create table asu_degesta.types_of_products
(
    types_of_products_id int auto_increment
        primary key,
    code                 longtext not null,
    Name                 longtext not null
);

create table asu_degesta.typesofproducts
(
    TypesOfProductsId varchar(255) not null
        primary key,
    Name              longtext     not null
);

create table asu_degesta.reportcostsproductioncapacity
(
    id                   int auto_increment
        primary key,
    doc_id               varchar(255) not null,
    EquipmentId          int          not null,
    types_of_products_id varchar(255) not null,
    costs                int          not null,
    constraint FK_ReportCostsProductionCapacity_Equipments_EquipmentId
        foreign key (EquipmentId) references asu_degesta.equipments (EquipmentId)
            on delete cascade,
    constraint `FK_ReportCostsProductionCapacity_ReportCostsProductionCapacity_~`
        foreign key (doc_id) references asu_degesta.reportcostsproductioncapacity_id (doc_id)
            on delete cascade,
    constraint `FK_ReportCostsProductionCapacity_TypesOfProducts_types_of_produ~`
        foreign key (types_of_products_id) references asu_degesta.typesofproducts (TypesOfProductsId)
            on delete cascade
);

create index IX_ReportCostsProductionCapacity_EquipmentId
    on asu_degesta.reportcostsproductioncapacity (EquipmentId);

create index IX_ReportCostsProductionCapacity_doc_id
    on asu_degesta.reportcostsproductioncapacity (doc_id);

create index IX_ReportCostsProductionCapacity_types_of_products_id
    on asu_degesta.reportcostsproductioncapacity (types_of_products_id);

create table asu_degesta.units
(
    Units_ID int auto_increment
        primary key,
    Name     longtext not null
);

create table asu_degesta.forecastmaximumdemandproducts
(
    id                   int auto_increment
        primary key,
    doc_id               varchar(255) not null,
    types_of_products_id varchar(255) not null,
    demand               int          not null,
    units_id             int          not null,
    constraint `FK_ForecastMaximumDemandProducts_ForecastMaximumDemandProducts_~`
        foreign key (doc_id) references asu_degesta.forecastmaximumdemandproducts_id (doc_id)
            on delete cascade,
    constraint `FK_ForecastMaximumDemandProducts_TypesOfProducts_types_of_produ~`
        foreign key (types_of_products_id) references asu_degesta.typesofproducts (TypesOfProductsId)
            on delete cascade,
    constraint FK_ForecastMaximumDemandProducts_Units_units_id
        foreign key (units_id) references asu_degesta.units (Units_ID)
            on delete cascade
);

create index IX_ForecastMaximumDemandProducts_doc_id
    on asu_degesta.forecastmaximumdemandproducts (doc_id);

create index IX_ForecastMaximumDemandProducts_types_of_products_id
    on asu_degesta.forecastmaximumdemandproducts (types_of_products_id);

create index IX_ForecastMaximumDemandProducts_units_id
    on asu_degesta.forecastmaximumdemandproducts (units_id);

create table asu_degesta.monthlyproductreleaseplan
(
    id                   int auto_increment
        primary key,
    doc_id               varchar(255) not null,
    types_of_products_id varchar(255) not null,
    count                double       not null,
    units_id             int          not null,
    constraint FK_MonthlyProductReleasePlan_MonthlyProductReleasePlan_id_doc_id
        foreign key (doc_id) references asu_degesta.monthlyproductreleaseplan_id (doc_id)
            on delete cascade,
    constraint `FK_MonthlyProductReleasePlan_TypesOfProducts_types_of_products_~`
        foreign key (types_of_products_id) references asu_degesta.typesofproducts (TypesOfProductsId)
            on delete cascade,
    constraint FK_MonthlyProductReleasePlan_Units_units_id
        foreign key (units_id) references asu_degesta.units (Units_ID)
            on delete cascade
);

create index IX_MonthlyProductReleasePlan_doc_id
    on asu_degesta.monthlyproductreleaseplan (doc_id);

create index IX_MonthlyProductReleasePlan_types_of_products_id
    on asu_degesta.monthlyproductreleaseplan (types_of_products_id);

create index IX_MonthlyProductReleasePlan_units_id
    on asu_degesta.monthlyproductreleaseplan (units_id);

create table asu_degesta.pricelist
(
    id                   int auto_increment
        primary key,
    doc_id               varchar(255)  not null,
    types_of_products_id varchar(255)  not null,
    price                int default 0 not null,
    units_id             int           not null,
    constraint FK_PriceList_PriceList_id_doc_id
        foreign key (doc_id) references asu_degesta.pricelist_id (doc_id)
            on delete cascade,
    constraint FK_PriceList_TypesOfProducts_types_of_products_id
        foreign key (types_of_products_id) references asu_degesta.typesofproducts (TypesOfProductsId)
            on delete cascade,
    constraint FK_PriceList_Units_units_id
        foreign key (units_id) references asu_degesta.units (Units_ID)
            on delete cascade
);

create index IX_PriceList_doc_id
    on asu_degesta.pricelist (doc_id);

create index IX_PriceList_types_of_products_id
    on asu_degesta.pricelist (types_of_products_id);

create index IX_PriceList_units_id
    on asu_degesta.pricelist (units_id);

create table asu_degesta.reportavailableequipmentperformance
(
    id          int auto_increment
        primary key,
    doc_id      varchar(255)  not null,
    perfomance  int           not null,
    units_id    int           not null,
    EquipmentId int default 0 not null,
    constraint FK_ReportAvailableEquipmentPerformance_Equipments_EquipmentId
        foreign key (EquipmentId) references asu_degesta.equipments (EquipmentId)
            on delete cascade,
    constraint `FK_ReportAvailableEquipmentPerformance_ReportAvailableEquipment~`
        foreign key (doc_id) references asu_degesta.reportavailableequipmentperformance_id (doc_id)
            on delete cascade,
    constraint FK_ReportAvailableEquipmentPerformance_Units_units_id
        foreign key (units_id) references asu_degesta.units (Units_ID)
            on delete cascade
);

create index IX_ReportAvailableEquipmentPerformance_EquipmentId
    on asu_degesta.reportavailableequipmentperformance (EquipmentId);

create index IX_ReportAvailableEquipmentPerformance_doc_id
    on asu_degesta.reportavailableequipmentperformance (doc_id);

create index IX_ReportAvailableEquipmentPerformance_units_id
    on asu_degesta.reportavailableequipmentperformance (units_id);

create table asu_degesta.reportmatherialcosts
(
    id                        int auto_increment
        primary key,
    doc_id                    varchar(255) not null,
    types_of_products_id      varchar(255) not null,
    direct_costs              double       not null,
    overhead_production_costs double       not null,
    general_business_invoices double       not null,
    units_id                  int          not null,
    constraint FK_ReportMatherialCosts_ReportMatherialCosts_id_doc_id
        foreign key (doc_id) references asu_degesta.reportmatherialcosts_id (doc_id)
            on delete cascade,
    constraint FK_ReportMatherialCosts_TypesOfProducts_types_of_products_id
        foreign key (types_of_products_id) references asu_degesta.typesofproducts (TypesOfProductsId)
            on delete cascade,
    constraint FK_ReportMatherialCosts_Units_units_id
        foreign key (units_id) references asu_degesta.units (Units_ID)
            on delete cascade
);

create index IX_ReportMatherialCosts_doc_id
    on asu_degesta.reportmatherialcosts (doc_id);

create index IX_ReportMatherialCosts_types_of_products_id
    on asu_degesta.reportmatherialcosts (types_of_products_id);

create table asu_degesta.reportproductcost
(
    id                   int auto_increment
        primary key,
    doc_id               varchar(255) not null,
    types_of_products_id varchar(255) not null,
    cost_price           double       not null,
    units_id             int          not null,
    constraint FK_ReportProductCost_ReportProductCost_id_doc_id
        foreign key (doc_id) references asu_degesta.reportproductcost_id (doc_id)
            on delete cascade,
    constraint FK_ReportProductCost_TypesOfProducts_types_of_products_id
        foreign key (types_of_products_id) references asu_degesta.typesofproducts (TypesOfProductsId)
            on delete cascade,
    constraint FK_ReportProductCost_Units_units_id
        foreign key (units_id) references asu_degesta.units (Units_ID)
            on delete cascade
);

create index IX_ReportProductCost_doc_id
    on asu_degesta.reportproductcost (doc_id);

create index IX_ReportProductCost_types_of_products_id
    on asu_degesta.reportproductcost (types_of_products_id);

create index IX_ReportProductCost_units_id
    on asu_degesta.reportproductcost (units_id);

create table asu_degesta.reportproductplan
(
    id                   int auto_increment
        primary key,
    doc_id               varchar(255) not null,
    types_of_products_id varchar(255) not null,
    produced             int          not null,
    units_id             int          not null,
    constraint FK_ReportProductPlan_ReportProductPlan_id_doc_id
        foreign key (doc_id) references asu_degesta.reportproductplan_id (doc_id)
            on delete cascade,
    constraint FK_ReportProductPlan_Units_units_id
        foreign key (units_id) references asu_degesta.units (Units_ID)
            on delete cascade
);

create index IX_ReportProductPlan_doc_id
    on asu_degesta.reportproductplan (doc_id);

create index IX_ReportProductPlan_types_of_products_id
    on asu_degesta.reportproductplan (types_of_products_id);

create table asu_degesta.specificationcontractmaterials
(
    id                   int auto_increment
        primary key,
    doc_id               varchar(255)  not null,
    count_of_matherials  int           not null,
    price_per_unit       double        not null,
    price                double        not null,
    units_id             int default 0 not null,
    types_of_products_id varchar(255)  not null,
    spec_units_id        int           null,
    constraint `FK_SpecificationContractMaterials_SpecificationContractMaterial~`
        foreign key (doc_id) references asu_degesta.specificationcontractmaterials_id (doc_id)
            on delete cascade,
    constraint `FK_SpecificationContractMaterials_TypesOfProducts_types_of_prod~`
        foreign key (types_of_products_id) references asu_degesta.typesofproducts (TypesOfProductsId)
            on delete cascade,
    constraint FK_SpecificationContractMaterials_Units_units_id
        foreign key (units_id) references asu_degesta.units (Units_ID)
            on delete cascade
);

create index IX_SpecificationContractMaterials_Units_ID
    on asu_degesta.specificationcontractmaterials (units_id);

create index IX_SpecificationContractMaterials_doc_id
    on asu_degesta.specificationcontractmaterials (doc_id);

create index IX_SpecificationContractMaterials_types_of_products_id
    on asu_degesta.specificationcontractmaterials (types_of_products_id);
