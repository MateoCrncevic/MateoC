using Microsoft.ApplicationBlocks.Data;
using RWA.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace RWA.Models
{
    public class Repository
    {
        public static DataSet ds { get; set; }
        private static string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        private static string sqlSortType;


        public static Login CheckLogin(string mail, string pwd)
        {

            DataSet ds = SqlHelper.ExecuteDataset(cs, "GetLogins");

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                if (row["Email"].ToString() == mail && row["Passwrd"].ToString() == pwd)
                {
                    return new Login { Email = row["Email"].ToString(), Nickname = row["Nickname"].ToString() };
                }
            }
            throw new Exception("No such login!");

        }

        public static bool RegisterNewUser(string email, string nickname, string pwd)
        {


            try
            {
                SqlHelper.ExecuteDataset(cs, "RegisterUser", email, nickname, pwd);
                return true;
            }
            catch (Exception)
            {

                return false;
            }



        }

        public static Customer GetCustomer(int idKupac)
        {
            DataRow row = SqlHelper.ExecuteDataset(cs, "GetCustomer", idKupac).Tables[0].Rows[0];

            return GetCustomerFromDataRow(row);
        }

        public static IEnumerable<Customer> GetCustomers(int countryID, int? townID, SortType? sortType, int customersPerPage, int page)
        {
            switch (sortType)
            {
                case null:
                    sqlSortType = " Kupac.Ime desc";
                    break;
                case SortType.SortByNameAsc:
                    sqlSortType = " Kupac.Ime asc";
                    break;
                case SortType.SortByNameDesc:
                    sqlSortType = " Kupac.Ime desc";
                    break;
                case SortType.SortBySurnameAsc:
                    sqlSortType = " Kupac.Prezime asc";
                    break;
                case SortType.SortBySurnameDesc:
                    sqlSortType = " Kupac.Prezime desc";
                    break;
            }
            string sqlTownSort;

            if (townID == null)
            {
                sqlTownSort = $" where d.IDDrzava = {countryID} ";
            }

            else
            {
                sqlTownSort = $" where Kupac.GradID={townID} ";
            }

            var sql = ($"select  Kupac.IDKupac, Kupac.Ime,Kupac.Prezime, " +
                                $"Kupac.Telefon,Kupac.Email,Kupac.GradID, g.Naziv as NazivGrada, d.IDDrzava, d.Naziv as NazivDrzave from Kupac  " +
                                $"join Grad as g on kupac.GradID = g.IDGrad join Drzava as d on d.IDDrzava = g.DrzavaID" +
                                $"  { sqlTownSort }" +
                                $"  order by {sqlSortType} offset {customersPerPage * (page - 1) } rows" +
                                $" fetch next { customersPerPage } rows only");

            var result = SqlHelper.ExecuteReader(cs, CommandType.Text, sql);
            var customers = new List<Customer>();
            while (result.Read())
            {
                var country = new Country
                {
                    IDDrzava = (int)result["IdDrzava"],
                    Naziv = result["NazivGrada"].ToString(),
                };
                var town = new Town
                {
                    IDGrad = (int)result["GradID"],
                    Naziv = result["NazivDrzave"].ToString(),
                    DrzavaID = (int)result["IDDrzava"],
                    Country = country
                };

                customers.Add(
                    new Customer
                    {
                        IDKupac = (int)result["IdKupac"],
                        Ime = result["ime"].ToString(),
                        Prezime = result["prezime"].ToString(),
                        Email = result["Email"].ToString(),
                        Telefon = result["Telefon"].ToString(),
                        GradID = result["GradID"] != DBNull.Value ? (int)result["GradID"] : 1,
                        Town = town
                    }
                    );
            }

            return customers;
        }

        public static List<int> GetCountryID(int customerID)
        {
           var drzaveID = new List<int>();
            var sql = ($"select d.IDDrzava from Kupac inner join grad as g on kupac.GradID = g.IDGrad join drzava as d on d.IDDrzava = g.DrzavaID where IDKupac ={customerID} ");
            var result = SqlHelper.ExecuteReader(cs, CommandType.Text, sql);

            while (result.Read())

            {
                drzaveID.Add(
                     (int)result["IDDrzava"]

                );
            }
                
            return drzaveID;
 
                
        }
            public static Country GetCountry(int countryId)
        {
            DataRow row = SqlHelper.ExecuteDataset(cs, "GetCountry", countryId).Tables[0].Rows[0];
            return new Country
            {
                IDDrzava = (int)row["IDDrzava"],
                Naziv = row["Naziv"].ToString(),
            };


        }



        private static Customer GetCustomerFromDataRow(DataRow row)
        {
            return new Customer
            {
                IDKupac = (int)row["IdKupac"],
                Ime = row["ime"].ToString(),
                Prezime = row["prezime"].ToString(),
                Email = row["Email"].ToString(),
                Telefon = row["Telefon"].ToString(),
                GradID = row["GradID"] != DBNull.Value ? (int)row["GradID"] : 1,

            };
        }


        public static Town GetTown(int? townID)
        {

            DataRow row = SqlHelper.ExecuteDataset(cs, "GetTown", townID).Tables[0].Rows[0];
            return new Town
            {
                IDGrad = (int)row["IDGrad"],
                DrzavaID = (int)row["DrzavaID"],
                Naziv = row["Naziv"].ToString()
            };
        }
        public static List<Town> GetTowns(int countryID)
        {
            List<Town> towns = new List<Town>();
            DataSet ds = SqlHelper.ExecuteDataset(cs, "GetTowns", countryID);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                towns.Add(new Town
                {
                    IDGrad = (int)row["IDGrad"],
                    Naziv = row["Naziv"].ToString(),
                    DrzavaID = (int)row["DrzavaID"]
                });
            }
            return towns;
        }
        public static void UpdateCustomer(Customer customer)
        {
            SqlHelper.ExecuteNonQuery(cs, "UpdateCustomer", customer.IDKupac, customer.Ime, customer.Prezime, customer.Email, customer.Telefon, customer.grad);
        }
        public static Bill GetCustomerBill(int customerID)
        {
            DataRow row = SqlHelper.ExecuteDataset(cs, "GetCustomerBill", customerID).Tables[0].Rows[0];
            return GetBillFromDataRow(row);
        }
        public static IEnumerable<Bill> GetCustomersBills(int id)
        {
            ds = SqlHelper.ExecuteDataset(cs, "GetCustomersBills", id);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                yield return GetBillFromDataRow(row);
            }

        }
        public static List<Country> GetCountries()
        {

            List<Country> countries = new List<Country>();
            DataSet ds = SqlHelper.ExecuteDataset(cs, "GetCountries");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                countries.Add(new Country
                {
                    IDDrzava = (int)row["IDDrzava"],
                    Naziv = row["Naziv"].ToString(),
                });
            }
            return countries;
        }

        public static List<Product> GetProducts()
        {
            SubCategory subCategory = new SubCategory();
            List<Product> products = new List<Product>();
            var sql = ($"Select p.IDProizvod,p.Naziv,p.BrojProizvoda,p.Boja,p.MinimalnaKolicinaNaSkladistu,Cast(p.CijenaBezPdv as decimal (10,2)) as CijenaBezPdv,p.PotkategorijaID,pk.IDPotkategorija,pk.Naziv as PotKategorija" +
                $" from Proizvod as p left join Potkategorija as pk on p.PotkategorijaID=pk.IDPotkategorija");
            var result = SqlHelper.ExecuteReader(cs, CommandType.Text, sql);
            while (result.Read())
            {
                if (result["IDPotkategorija"] == DBNull.Value)
                {
                    subCategory = null;
                }
                else
                {
                    subCategory = new SubCategory
                    {

                        IDPotKategorija = (int)result["IDPotkategorija"],
                        Naziv = result["Potkategorija"].ToString()
                    };

                }

                products.Add(new Product
                {
                    IdProizvod = (int)result["IDProizvod"],
                    Naziv = result["Naziv"].ToString(),
                    BrojProizvoda = result["BrojProizvoda"].ToString(),
                    Boja = result["Boja"] == DBNull.Value ? null : result["Boja"].ToString(),
                    MinKolicinaNaSkladistu = (short)result["MinimalnaKolicinaNaSkladistu"],
                    CijenaBezPdva = (decimal)result["CijenaBezPdv"],
                    PotKategorijaID = result["PotkategorijaID"] == DBNull.Value ? null : (int?)result["PotkategorijaID"],
                    Subcategory = subCategory
                });
            };
            return products;
        }

        public static Product GetProduct(int id)
        {
            Product product = new Product(); 
            SubCategory subCategory = new SubCategory();
            var sql = ($"Select p.IDProizvod,p.Naziv,p.BrojProizvoda,p.Boja,p.MinimalnaKolicinaNaSkladistu,Cast(p.CijenaBezPdv as decimal (10,2)) as CijenaBezPdv,p.PotkategorijaID,pk.IDPotkategorija,pk.Naziv as PotKategorija" +
                $" from Proizvod as p left join Potkategorija as pk on p.PotkategorijaID=pk.IDPotkategorija where IDProizvod={id}");
            var result = SqlHelper.ExecuteReader(cs, CommandType.Text, sql);
            while (result.Read())
            {
                if (result["IDPotkategorija"] == DBNull.Value)
                {
                    subCategory = null;
                }
                else
                {
                    subCategory = new SubCategory
                    {

                        IDPotKategorija = (int)result["IDPotkategorija"],
                        Naziv = result["Potkategorija"].ToString()
                    };

                }

                product=(new Product
                {
                    IdProizvod = (int)result["IDProizvod"],
                    Naziv = result["Naziv"].ToString(),
                    BrojProizvoda = result["BrojProizvoda"].ToString(),
                    Boja = result["Boja"] == DBNull.Value ? null : result["Boja"].ToString(),
                    MinKolicinaNaSkladistu = (short)result["MinimalnaKolicinaNaSkladistu"],
                    CijenaBezPdva = (decimal)result["CijenaBezPdv"],
                    PotKategorijaID = result["PotkategorijaID"] == DBNull.Value ? null : (int?)result["PotkategorijaID"],
                    Subcategory = subCategory
                });
            };
            return product;

        }
        public static void UpdateProduct(Product product)
        {
            SqlHelper.ExecuteNonQuery(cs, "UpdateProduct", product.IdProizvod, product.Naziv, product.BrojProizvoda, product.Boja, product.MinKolicinaNaSkladistu, product.CijenaBezPdva, product.PotKategorijaID);

        }
        public static void InsertProduct(Product product)
        {
            SqlHelper.ExecuteNonQuery(cs, "InsertProduct", product.Naziv, product.BrojProizvoda, product.Boja, product.MinKolicinaNaSkladistu, product.CijenaBezPdva, product.PotKategorijaID);
        }

        public static void DeleteProduct(int id)
        {
            SqlHelper.ExecuteNonQuery(cs, "DeleteProduct", id);
        }

        public static List<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();
            var sql = $"Select* from Kategorija";
            var result = SqlHelper.ExecuteReader(cs, CommandType.Text, sql);
            while (result.Read())
            {
                categories.Add(new Category
                {
                    IDKategorija = (int)result["IDKategorija"],
                    Naziv = result["Naziv"].ToString()

                });

            }
            return categories;


        }
        public static Category GetCategory(int id)
        {
            Category category = new Category();
            var sql = $"Select*from Kategorija where IDKategorija={id}";
            var result = SqlHelper.ExecuteReader(cs, CommandType.Text, sql);
            while (result.Read())
            {
                category =new Category { 
                    IDKategorija = (int)result["IDKategorija"],
                    Naziv = result["Naziv"].ToString()
                };

            }
            return category;

        }


        public static void UpdateCategory(Category category)
        {
            SqlHelper.ExecuteNonQuery(cs, "UpdateCategory", category.IDKategorija, category.Naziv);

        }
        public static void InsertCategory(Category category)
        {
            SqlHelper.ExecuteNonQuery(cs, "InsertCategory", category.Naziv);
        }

        public static void DeleteCategory(int id)
        {
            SqlHelper.ExecuteNonQuery(cs, "DeleteCategory", id);
        }

        public static List<SubCategory> GetSubCategories()
        {
            List<SubCategory> subcategories = new List<SubCategory>();
            var sql = $"Select* from PotKategorija as pk ";
            var result = SqlHelper.ExecuteReader(cs, CommandType.Text, sql);
            while (result.Read())
            {
                
                subcategories.Add(new SubCategory
                {
                    IDPotKategorija = (int)result["IDPotkategorija"],
                    Naziv = result["Naziv"].ToString(),
                    KategorijaID=(int)result["KategorijaID"]
                }); 

            }
            return subcategories;
        }
        public static SubCategory GetSubCategory(int id)
        {
            SubCategory subCategory = new SubCategory();
           
            var sql = $"Select* from PotKategorija as pk where pk.IDPotKategorija={id}";
            var result = SqlHelper.ExecuteReader(cs, CommandType.Text, sql);
            while (result.Read())
            {

               subCategory = new SubCategory
                {
                    IDPotKategorija = (int)result["IDPotkategorija"],                 
                    KategorijaID = (int)result["KategorijaID"],
                    Naziv = result["Naziv"].ToString(),
               };

            }
            return subCategory;
        }

        public static List<Stavka> GetStavke(int id)
        {
            Product product = new Product();
            List<Stavka> stavke = new List<Stavka>();
            var sql = $"select s.IDStavka,s.RacunID,s.Kolicina,s.ProizvodID,Cast(s.PopustUPostocima as decimal (10,2)) as PopustUPostocima," +
                $"Cast(CijenaPoKomadu as decimal (10,2)) as CijenaPoKomadu,Cast(s.UkupnaCijena as decimal (38,6)) as UkupnaCijena," +
                $"p.IDProizvod,p.Naziv from Stavka as s inner join Proizvod as p on s.ProizvodID = IDProizvod where RacunID ={id}";
            var result = SqlHelper.ExecuteReader(cs, CommandType.Text, sql);
            while (result.Read())
            {
                product = new Product
                {
                    IdProizvod = (int)result["IDProizvod"],
                    Naziv=result["Naziv"].ToString()

                };
                stavke.Add(new Stavka
                {
                    IDStavka = (int)result["IDStavka"],
                    RacunID = (int)result["RacunID"],
                    Kolicina = (short)result["Kolicina"],
                    ProizvodID = (int)result["ProizvodID"],
                    PopustUPostocima = (decimal)result["PopustUPostocima"],
                    CijenaPoKomadu = (decimal)result["CijenaPoKomadu"],
                    UkupnaCijena = (decimal)result["UkupnaCijena"],
                    Product = product
                }) ;

                
            }
            return stavke;
        }

        public static void UpdateSubCategory(SubCategory subCategory)
        {
            SqlHelper.ExecuteNonQuery(cs, "UpdateSubCategory", subCategory.IDPotKategorija, subCategory.Naziv,subCategory.KategorijaID);
        }
        public static void InsertSubCategory(SubCategory subCategory)
        {
            SqlHelper.ExecuteNonQuery(cs, "InsertSubCategory", subCategory.Naziv,subCategory.KategorijaID);
        }

        public static void DeleteSubCategory(int id)
        {
            SqlHelper.ExecuteNonQuery(cs, "DeleteSubCategory", id);
        }




        public static Bill GetBillFromDataRow(DataRow row)
        {
            return new Bill
            {
                IDRacun = (int)row["IdRacun"],
                BrojRacuna = row["BrojRacuna"].ToString(),
                DatumIzdavanja = (DateTime)row["DatumIzdavanja"],
                Komentar = row["Komentar"].ToString()
            };
        }
    }
}