using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonAct
{
    internal class Visit : Customer
    {
        private Customer customer;
        private DateTime date;
        private double serviceExpense;
        private double productExpense;

        public Visit()
        {
        
            this.serviceExpense = 0.0;
            this.productExpense = 0.0;
        }
        public Visit(String name, DateTime date)
        {
            this.customer = new Customer(name);
            this.date = date;
            this.serviceExpense = 0.0;
            this.productExpense = 0.0;
        }

        public String getName()
        {
            return this.customer.getName();
        }

        public double getProductExpense()
        {
            return this.productExpense;
        }

        public void setProductExpense(double ex)
        {
            this.productExpense = ex;
        }

        public double getServiceExpense()
        {
            return this.serviceExpense;
        }

        public void setServiceExpense(double ex)
        {
            this.serviceExpense = ex;
        }

        public double getTotalExpense()
        {
            return this.serviceExpense + this.productExpense;
        }
    }
}
