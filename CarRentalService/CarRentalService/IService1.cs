using CsvHelper.Configuration.Attributes;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace CarRentalService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string InsertCarDetails(CarDetails carInfo);

        [OperationContract]
        string DeleteCarDetails(CarDetails carInfo);

        [OperationContract]
        string UpdateCarDetails(CarDetails carInfo);

        [OperationContract]
        DataSet SelectCarDetails();

        [OperationContract]
        string RentCar(People people);
        [OperationContract]
        string DeletePeopleDetails(People people);

        [OperationContract]
        DataSet SelectPeopleDetails();

    }
    [DataContract]
    public class CarDetails
    {
        string carbrand;
        string carmodel;
        int production_year;
        int engine_power;
        int id;
        string fuel_type;
        [DataMember]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [DataMember]
        public string CarBrand
        {
            get { return carbrand; }
            set { carbrand = value; }
        }
        [DataMember]
        public string CarModel
        {
            get { return carmodel; }
            set { carmodel = value; }
        }
        [DataMember]
        public int ProductionYear
        {
            get { return production_year; }
            set { production_year = value; }
        }
        [DataMember]
        public int EnginePower
        {
            get { return engine_power; }
            set { engine_power = value; }
        }
        [DataMember]
        public string FuelType
        {
            get { return fuel_type; }
            set { fuel_type = value; }
        }

    }

    [DataContract]
    public class People
    {
        string name;
        string surename;
        int id;
        int carid;

        [DataMember]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [DataMember]
        public string Surename
        {
            get { return surename; }
            set { surename = value; }
        }

        [DataMember]
        public DateTime Date { get; set; }

        [DataMember]
        public int CarId
        {
            get { return carid; }
            set { carid = value; }
        }
    }
}
