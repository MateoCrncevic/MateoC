using System.Collections.Generic;

namespace RWA.Models.ViewModel
{
    public class ShowCustomersVM
    {
        public IEnumerable<Country> Countries { get; set; }
        public IEnumerable<Town> Towns { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
        public int SortByType { get; set; }

        public List<Sort> Sorts { get; set; }
        public int CustomersPerOnePage { get; set; }

        public List<CustomersPerPage> CustomersPerPage { get; set; }

        public int Page { get; set; }

        public ShowCustomersVM()
        {
            CustomersPerPage = new List<CustomersPerPage>();
            CustomersPerPage.Add(new CustomersPerPage
            {
                ID = 10,
                BrojKupacaPoStranici = 10
            });
            CustomersPerPage.Add(new CustomersPerPage
            {
                ID = 20,
                BrojKupacaPoStranici = 20
            });
            CustomersPerPage.Add(new CustomersPerPage
            {
                ID = 25,
                BrojKupacaPoStranici = 25
            });
            CustomersPerPage.Add(new CustomersPerPage
            {
                ID = 50,
                BrojKupacaPoStranici = 50
            }
               );
            Sorts = new List<Sort>();
            Sorts.Add(new Sort
            {
                ID = 0,
                Naziv = "Sortirajte po imenu padajuće"
            }
            );
            Sorts.Add(new Sort
            {
                ID = 1,
                Naziv = "Sortirajte po imenu uzlazno"
            }
            );
            Sorts.Add(new Sort
            {
                ID = 2,
                Naziv = "Sortirajte po prezimenu silazno"
            }
            );
            Sorts.Add(new Sort
            {
                ID = 3,
                Naziv = "Sortirajte po prezimenu uzlazno"
            }


           );
        }

    }
}