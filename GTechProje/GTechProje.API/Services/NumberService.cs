using GTechProje.API.Models;
using GTechProje.API.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace GTechProje.API.Services
{
    public class NumberService : INumberService
    {
       
        private NumbersAPIContext _context;
        public NumberService(NumbersAPIContext context)
        {
            _context = context;
        }

        
        public int SaveNumber(Number numberModel)
        {
            ResponseModel model = new ResponseModel();
            ArrayList arr = new ArrayList();           
            int sum = 0;
            try
            {
                if (numberModel == null)
                {
                    _context.Add<Number>(numberModel);
                    model.Messsage = "Number Inserted Successfully";
                    _context.SaveChanges();
                    model.IsSuccess = true;
                    arr.Add(numberModel.Value);
                }             
                    foreach (int item in arr)
                    {
                        sum += item;
                    }               
            }

            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
            return sum;

            arr.Clear();

        }
    }
}
