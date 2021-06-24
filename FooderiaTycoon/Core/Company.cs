using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace FooderiaTycoon.Core
{
    public class Company
    {
        protected string _name;
        protected int _inaugurationDate;
        protected CompanyColor _colorScheme;
        protected string _type ;
        protected int _companyValue;
        protected int _brands;
        protected CEO _boss;
        public Company(string name, int inaugurationDate, CompanyColor colorScheme, string type, int companyValue, int brands, CEO boss)
        {
            _name = name;
            _inaugurationDate = inaugurationDate;
            _colorScheme = colorScheme;
            _type = type ;
            _companyValue = companyValue;
            _brands = brands;
            _boss = boss;
        }
        
        
    }
}