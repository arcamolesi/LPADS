using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIBLIOTECA.CAMADAS.BLL
{
    public class Emprestimo
    {
        public List<MODEL.Emprestimo> Select()
        {
            DAL.Emprestimo dalEmp = new DAL.Emprestimo();
            return dalEmp.Select(); 
        }

        public void  Insert(MODEL.Emprestimo emprestimo)
        {
            DAL.Emprestimo dalEmp = new DAL.Emprestimo();
            dalEmp.Insert(emprestimo);
        }

        public void Update(MODEL.Emprestimo emprestimo)
        {
            DAL.Emprestimo dalEmp = new DAL.Emprestimo();
            dalEmp.Update(emprestimo);
        }

        public void Delete(int idEmprestimo)
        {
            DAL.Emprestimo dalEmp = new DAL.Emprestimo();
            dalEmp.Delete (idEmprestimo);
        }
    }
}
