﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Common
{
    [ServiceContract]
    public interface ICompanyService
    {
        [OperationContract]
        User Login(string username, string pass);

        [OperationContract]
        bool LogOut(string username, string pass);

        [OperationContract]
        bool AddUser(User user);

        [OperationContract]
        bool EditUser(User userMain, User editUser);

        [OperationContract]
        List<User> GetAllEmployees();

        [OperationContract]
        User GetUser(string username);

        [OperationContract]
        bool CreateProject(Project prj);

        [OperationContract]
        bool DeleteProject(Project prj);

        [OperationContract]
        List<Project> GetAllProjects();

        [OperationContract]
        bool UpdateProject(Project p);

        [OperationContract]
        List<string> GetAllParnterCompanies(string username);

        [OperationContract]
        bool AddParnterCompany(string ceo, string partner);
     
    }
}
