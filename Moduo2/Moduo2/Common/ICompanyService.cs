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
        List<User> GetAllLogedUsers();

        [OperationContract]
        List<User> GetAllUsers();

        [OperationContract]
        User GetUser(string username);

        [OperationContract]
        List<User> GetOnlineUsers();

        [OperationContract]
        List<string> GetCompanyes();

        [OperationContract]
        bool UpdatePass(string username, string pass);

        [OperationContract]
        List<Tim> GetAllTims();

        [OperationContract]
        List<Project> GetProjects();

        [OperationContract]
        bool AddProjectToBase(Project proj);

        [OperationContract]
        bool AddTeam(Tim tim);

        [OperationContract]
        List<User> GetUsersByType(Roles role);

        [OperationContract]
        Tim GetTimByName(string name);

        [OperationContract]
        bool AddTeamToProject(string nazivProjekta, string nazivTima);




        

    }
}
