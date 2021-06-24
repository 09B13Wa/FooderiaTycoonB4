using System.Security.Cryptography.X509Certificates;

namespace FooderiaTycoon.Core
{
    public struct CEO
    {
        private Pawn _pawn;
        private Company _company;
        
        public CEO(Pawn pawn, Company company)
        {
            _pawn = pawn;
            _company = company;
        }

        public Pawn Pawn
        {
            get => _pawn;
            set => _pawn = value;
        }

        public Company Company
        {
            get => _company;
            set => _company = value;
        }
    }
    
}