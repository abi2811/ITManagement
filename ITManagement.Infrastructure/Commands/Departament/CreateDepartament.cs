using System;
namespace ITManagement.Infrastructure.Commands.Departament
{
    public class CreateDepartament : ICommand
    {
        public string Name { get; set; }
    }
}
