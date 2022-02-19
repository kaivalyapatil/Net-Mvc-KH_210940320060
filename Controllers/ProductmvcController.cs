using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using KH_210940320060.Models;

namespace KH_210940320060.Controllers
{
    public class ProductmvcController : Controller
    {
        // GET: Productmvc
        SqlConnection sc = new SqlConnection();
        public ActionResult Index()
        {
            sc.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ExamFinal;Integrated Security=True";
            sc.Open();
            SqlCommand cm = new SqlCommand();
            cm.Connection = sc;
            cm.CommandType = System.Data.CommandType.Text;
            cm.CommandText = "select * from Products";
            List<ProductModel> list = new List<ProductModel>();

            try
            {
                SqlDataReader dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    ProductModel s = new ProductModel();
                    s.ProductId = (int)dr["ProductId"];
                    s.ProductName = (string)dr["ProductName"];
                    s.Rate = (decimal)dr["Rate"];
                    s.CategoryName = (string)dr["CategoryName"];
                    s.Description = (string)dr["Description"];
                    list.Add(s);
                }
                sc.Close();
            }
            catch (Exception e)
            {

            }
            return View(list);
        }

        // GET: Productmvc/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Productmvc/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Productmvc/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Productmvc/Edit/5
        public ActionResult Edit(int id)
        {
            sc.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ExamFinal;Integrated Security=True";
            sc.Open();
            SqlCommand cd = new SqlCommand();
            cd.Connection = sc;
            cd.CommandType = System.Data.CommandType.Text;
            cd.CommandText = "select * from Products where ProductId=@Id";
            cd.Parameters.AddWithValue("@Id", id);
            SqlDataReader dr = cd.ExecuteReader();
            ProductModel obj = null;
            try
            {
                if (dr.Read())
                {
                    obj = new ProductModel { ProductId = (int)id,ProductName = (string)dr["ProductName"], Rate = (decimal)dr["Rate"], CategoryName = (string)dr["CategoryName"], Description=(string)dr["Description"] };
                }
                sc.Close();
            }
            catch (Exception e)
            {

            }

            return View(obj);
        }

        // POST: Productmvc/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ProductModel pmd)
        {
            try
            {
                sc.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PracticeForExam;Integrated Security=True";
                sc.Open();
                SqlCommand cd = new SqlCommand();
                cd.Connection = sc;
                cd.CommandType = System.Data.CommandType.Text;
                cd.CommandText = "update Products set ProductId=@ProductId, ProductName=@ProductName,Rate=@Rate,CategoryName=@CategoryName,Description=@Description where ProductId=@ProductId";
                
                cd.Parameters.AddWithValue("@ProductId",id);
                cd.Parameters.AddWithValue("@ProductName", pmd.ProductName);
                cd.Parameters.AddWithValue("@Rate", pmd.Rate);
                cd.Parameters.AddWithValue("@CategoryName", pmd.CategoryName);
                cd.Parameters.AddWithValue("@Description", pmd.Description);
                cd.ExecuteNonQuery();
                sc.Close();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Productmvc/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Productmvc/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
