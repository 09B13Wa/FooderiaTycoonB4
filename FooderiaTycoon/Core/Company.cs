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
        protected int _companyValue;
        protected int _brands;
        protected CEO _boss;
        public Company(string name, int inaugurationDate, CompanyColor colorScheme, string type, int companyValue, int brands, CEO boss)
        {
            _name = name;
            _inaugurationDate = inaugurationDate;
            _colorScheme = colorScheme;
            _companyValue = companyValue;
            _brands = brands;
            _boss = boss;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public CompanyColor ColorScheme
        {
            get => _colorScheme;
            set => _colorScheme = value;
        }

        public int CompanyValue
        {
            get => _companyValue;
            set => _companyValue = value;
        }

        public int Brands
        {
            get => _brands;
            set => _brands = value;
        }

        public CEO Boss
        {
            get => _boss;
            set => _boss = value;
        }
        
    }
}