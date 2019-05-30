using System;
using System.Web.Mvc;
using Sample.Models;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace Sample.Controllers
{
    public class MemberController : Controller
    {

        // GET: Member
        public ActionResult Index()
        {

            return View();
        }


        //Top画面のログイン
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        //情報を入力してDBへ登録した場合

        [HttpPost]  
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel lm)
        {

            //取得したレコードの格納場所となるDataSetクラスのインスタンスを作成
            DataSet ds = new DataSet();

            //テーブルを生成
            DataTable dt = new DataTable();

            //Viewに返す際に渡す値を生成   
            LoginModel viewModel = new LoginModel();

            //接続文字列の取得
            string constr = ConfigurationManager.ConnectionStrings["sqlsvr"].ConnectionString;

            //SQLServerへ接続
            using (SqlConnection con = new SqlConnection(constr))
            {
                //Fromに入力した情報を代入
                string Mail = Request.Form["Mail"];
                string Password = Request.Form["Password"];

                //DBに指定した値を選択するSQL文
                string query = "SELECT * FROM NewCustomer WHERE MailAddress = @Mail AND Password = @Password";

                using (SqlCommand cmd = new SqlCommand(query))
                {
                    //スカラー変数に入力した内容を配置
                    cmd.Parameters.Add(new SqlParameter("@Mail", Mail));
                    cmd.Parameters.Add(new SqlParameter("@Password", Password));
                    cmd.Connection = con;

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        //レコードを取得する
                        sda.Fill(ds);
                    }
                }
            }
            //データーテーブルのRowが一行実行された場合の条件式
            // ログイン成功
            if (ds.Tables[0].Rows.Count == 1)
            {
                //ログイン成功
                return View("Success");
            }
            //ログイン失敗
            else
            {
                //if (ModelState.IsValid)
                //{
                //    return View();}

                ////this.ModelState.AddModelError("","");
                //TempData["Login"] = new LoginModel();
                //return RedirectToAction("LoginModel","Models");

                //エラーメッセージを表記する
                //モデルにエラーの旨を伝える
                //ViewData["Message"] = "正しいをメールアドレスを入力して下さい";
                ModelState.AddModelError("Mail", "正しいメールアドレスを入力して下さい。");
                ModelState.AddModelError("Password", "正しいパスワードを入力して下さい。");
            }
            return View(viewModel);
        }   

        //Top画面の新規登録
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //値を入力して登録ボタンが押された場合

        [HttpPost]
        [ValidateAntiForgeryToken] //5/22AMまでできた→loginメソッドで何か修正したから使用できなくなった？

        public ActionResult Create(MemberBiddingModels bm)
        {

            //DatasetでDBにつなぐために、インスタンス生成
            DataSet ds = new DataSet();


            //viewに渡すモデルをインスタンス生成
            MemberBiddingModels viewModel = new MemberBiddingModels();

            //接続文字列の取得
            string constr = ConfigurationManager.ConnectionStrings["sqlsvr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string Mail = Request.Form["Mail"];
                string Password = Request.Form["Password"];

                //DBに登録するSQL文
                string query = "INSERT INTO NewCustomer(MailAddress,Password) VALUES (@Mail,@Password)";

                using (SqlCommand cmd = new SqlCommand(query))
                {

                    //スカラー変数に入力した内容を配置
                    cmd.Parameters.Add(new SqlParameter("@Mail", Mail));
                    cmd.Parameters.Add(new SqlParameter("@Password", Password));
                    cmd.Connection = con;


                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(ds);
                    }
                }
            }
            return View(viewModel);
         }
        }
    }

////列追加
//dt.Columns.Add("MailAddress");
//dt.Columns.Add("Password");

////10行（仮）追加
//for (int i = 0; i < 10; i++)
//{
//    DataRow row = dt.NewRow();
//    dt.Rows.Add(row);
//}

////DataSet（メモリ）の中にテーブルを投入
//ds.Tables.Add(dt);

//【Part1】
//string MailAddress = Request.Form["MailAddress"];
//string Password = Request.Form["Password"];

//DataSet ds = new DataSet();
//string constr = ConfigurationManager.ConnectionStrings["sqlsvr"].ConnectionString;


//using (var connection = new SqlConnection(connectionString))
//using (var command = connection.CreateCommand())
//{
//    try
//    {
//        connection.Open();

//        command.CommandText = "INSERT INTO NewCustomer(MailAddress,Password) VALUES (@MailAddress,@Password)";

//        command.ExecuteNonQuery();
//    }
//    finally
//    {
//        connection.Close();
//    }

//}

//var db = Database.Open("Sample");
//var insertCommand = "Insert into NewCustomer(MailAddress,Password) values(@MailAdress,@Password)";
//db.Execute(insertCommand, MailAddress, Password);

//return View();

//}


//【Part2】
//        if (!ModelState.IsValid)
//            {

//            return View(bm);
//          }

//       var vm = new MemberModels() { Mail = bm.Mail, Password = bm.Password };
//           {
//             return View("Index", vm);
//                         }
//          } 
//       }
//      }


//【Part3】
// var MailAddress = "";
//var Password = "";



//MailAddress = Request.Form["MailAddress"];
//Password = Request.Form["Password"];

//var db = Database.Open("Sample");
//var insertCommand = "Insert into NewCustomer(MailAddress,Password) values(@MailAdress,@Password)";
//db.Execute(insertCommand, MailAddress, Password);
