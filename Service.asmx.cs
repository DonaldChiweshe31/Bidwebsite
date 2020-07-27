using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.OleDb;
using System.IO;

namespace BidWebsite
{
    /// <summary>
    /// Summary description for Service
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Service : System.Web.Services.WebService
    {

        public Service()
        {

            //Uncomment the following line if using designed components 
            //InitializeComponent(); 
        }

        OleDbConnection conn;

        public void connect()
        {
            try
            {
                conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0; Data Source = " + HttpContext.Current.Request.PhysicalApplicationPath + "/App_Data/BookStore.accdb");
                conn.Open();
            }
            catch (OleDbException oledb)
            {
                string logfile = HttpContext.Current.Request.PhysicalApplicationPath + "/App_Data/log.txt";
                FileStream fs = new FileStream(logfile, FileMode.Create);
                BufferedStream bs = new BufferedStream(fs);
                fs.Close();

                StreamWriter sw = new StreamWriter(logfile);
                sw.WriteLine("Unable to establish Connecton to Database");
                sw.WriteLine(oledb);
                sw.Close();
            }

        }

        [WebMethod]
        public string login(string email, string pass)
        {

            connect();

            OleDbCommand chkMail = conn.CreateCommand();
            chkMail.CommandText = "SELECT * FROM Users WHERE UserMail = '" + email + "'";
            OleDbDataReader mailReader = chkMail.ExecuteReader();

            if (mailReader != null && mailReader.HasRows) // User Found 
            {
                OleDbCommand chkPass = conn.CreateCommand();
                chkPass.CommandText = "SELECT * FROM Users WHERE UserMail = '" + email + "' AND Password = '" + pass + "'";
                OleDbDataReader passReader = chkPass.ExecuteReader();

                if (passReader != null && passReader.HasRows) // Checking if user with password and email in database 
                {
                    return "true"; // Password matches 
                }
                else
                {
                    return "false"; // Password does not match 
                }

            }
            else // User not found
            {
                return "UNF";
            }
        }

        [WebMethod] // Register a new user in database 
        public string registerU(string uMail, string uName, string uPass, string uQuest, string uAns)
        {
            try
            {
                connect();
                OleDbCommand chkUser = conn.CreateCommand();
                chkUser.CommandText = "SELECT * FROM Users WHERE [UserMail] = '" + uMail + "'";
                OleDbDataReader mailReader = chkUser.ExecuteReader();

                if (mailReader != null && mailReader.HasRows) // Checks if User already exists 
                {
                    return "false";
                }
                else // User NOT Found !! 
                {
                    OleDbCommand addUser = conn.CreateCommand();
                    addUser.CommandText = "INSERT INTO Users ([UserMail], [UserName], [Password], [Question], [Answer]) VALUES ('" + uMail + "', '" + uName + "', '" + uPass + "', '" + uQuest + "', '" + uAns + "')";
                    addUser.ExecuteNonQuery();

                    return "true";
                }

            }
            catch (OleDbException ole) // Error 
            {
                return ole.ToString();
            }
            finally
            {
                conn.Close();
            }

        }

        [WebMethod] // Gives question for User when Password forgotten 
        public string getQuestion(string uMail)
        {
            string question;

            try
            {
                connect();
                OleDbCommand chkMail = conn.CreateCommand();
                chkMail.CommandText = "SELECT [Question] FROM Users WHERE [UserMail] = '" + uMail + "'";
                OleDbDataReader mailReader = chkMail.ExecuteReader();

                if (mailReader != null && mailReader.HasRows) // Checks if user exists 
                {
                    mailReader.Read();
                    question = mailReader.GetString(0);
                    return question;
                }
                else // User not found 
                {
                    return "UNF";
                }
            }
            catch (OleDbException ole)
            {
                return ole.ToString();
            }
            finally
            {
                conn.Close();
            }

        }

        [WebMethod] // Gets answer to security question 
        public string getAnswer(string uMail, string Ans)
        {
            try
            {
                connect();
                OleDbCommand mailAnswer = conn.CreateCommand();
                mailAnswer.CommandText = "SELECT * FROM Users WHERE UserMail = '" + uMail + "' AND Answer = '" + Ans + "'";
                OleDbDataReader mailAnsReader = mailAnswer.ExecuteReader();

                if (mailAnsReader != null && mailAnsReader.HasRows)//Answer and UserEmail Match !! 
                {
                    return "true";
                }
                else // Answer is false 
                {
                    return "false";
                }
            }
            catch (OleDbException ole)
            {
                return ole.ToString();
            }
            finally
            {
                conn.Close();
            }
        }

        [WebMethod] // used to reset password if forgotten 
        public string resetPass(string uMail, string newPass)
        {
            try
            {
                connect();
                OleDbCommand newPasscmd = conn.CreateCommand();
                newPasscmd.CommandText = "UPDATE Users SET [Password] ='" + newPass + "' WHERE ([UserMail] = '" + uMail + "')";
                newPasscmd.ExecuteNonQuery();
                return "true";
            }
            catch (OleDbException ole)
            {
                return ole.ToString();
            }
            finally
            {
                conn.Close();
            }
        }

        [WebMethod] // Display User name 
        public string getName(string uMail)
        {
            try
            {
                connect();

                OleDbCommand getName = conn.CreateCommand();
                getName.CommandText = "SELECT [UserName] FROM Users WHERE UserMail = '" + uMail + "'";
                getName.ExecuteNonQuery();

                OleDbDataReader nameReader = getName.ExecuteReader();
                nameReader.Read();
                return nameReader.GetValue(0).ToString();
            }
            catch (OleDbException oledb)
            {
                return oledb.ToString();
            }
            finally
            {
                conn.Close();
            }

        }

        [WebMethod]  // updating user information 
        public string updateInfo(string uMail, string uName, string uPass, string uQuest, string uAns)
        {
            try
            {
                connect();
                OleDbCommand update = conn.CreateCommand();
                update.CommandText = "UPDATE Users SET [UserName] = '" + uName + "', [Password] = '" + uPass + "', [Question] = '" + uQuest + "', [Answer] = '" + uAns + "' WHERE (UserMail = '" + uMail + "')";
                update.ExecuteNonQuery();
                return "true";
            }
            catch (OleDbException ole)
            {
                return ole.ToString();
            }
            finally
            {
                conn.Close();
            }

        }

        [WebMethod] // adding a book to the database 
        public string addBook(string name, string author)
        {
            try
            {
                connect();

                OleDbCommand addBookCmd = conn.CreateCommand();
                addBookCmd.CommandText = "INSERT INTO Book ([BookName], [Author]) VALUES ('" + name + "', '" + author + "')";
                addBookCmd.ExecuteNonQuery();
                return "true";
            }
            catch (OleDbException ole)
            {
                return ole.ToString();
            }
            finally
            {
                conn.Close();
            }
        }

        [WebMethod] // gets the authour name to display 
        public string getAuthor(string bookID)
        {
            try
            {
                connect();
                OleDbCommand authCmd = conn.CreateCommand();
                authCmd.CommandText = "SELECT [Authour] FROM Book WHERE BookID = " + bookID + "";
                OleDbDataReader authReader = authCmd.ExecuteReader();

                authReader.Read();
                return authReader.GetValue(0).ToString();
            }
            catch (OleDbException oledb)
            {
                return oledb.ToString();
            }
            finally
            {
            }
        }

        [WebMethod] // Gets all books ! 
        public DataSet getAllBooks()
        {
            try
            {
                connect();
                DataSet allBooks = new DataSet();
                OleDbDataAdapter dba = new OleDbDataAdapter("SELECT * FROM Book", conn);
                dba.Fill(allBooks, "Books");
                return allBooks;
            }
            catch
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        [WebMethod] // allows a user to rate a specified book 
        public string ratingBook(string email, int bookID, int UserRating)
        {
            try
            {
                connect();
                OleDbCommand chkUser = conn.CreateCommand();
                chkUser.CommandText = "SELECT * FROM [Ratings] WHERE Bookid = " + bookID + " AND [Email] = '" + email + "'";
                OleDbDataReader userReader = chkUser.ExecuteReader();

                if (userReader != null && userReader.HasRows) // checks if book already been rated by user 
                {
                    return "Choose another book. Cant rate same Book more than once !";
                }
                else // No existing rating found == add rating to database 
                {
                    OleDbCommand addRating = conn.CreateCommand();
                    addRating.CommandText = "INSERT INTO [Ratings] ([Bookid], [Email], [Rating]) VALUES ('" + bookID + "', '" + email + "', '" + UserRating + "')";
                    addRating.ExecuteNonQuery();

                    string logPath = HttpContext.Current.Request.PhysicalApplicationPath + "/App_Data/log.txt";
                    StreamWriter sw = new StreamWriter(logPath, true);
                    sw.WriteLine("Email : " + email + "\t BookID : " + bookID.ToString() + "\t Rating : " + UserRating.ToString());
                    sw.Close();

                    return "You just gave a rating of " + UserRating.ToString() + " out of 5";
                }

            }
            catch (OleDbException ole)
            {
                return ole.ToString();
            }
            finally
            {
                conn.Close();
            }
        }

        [WebMethod] // working out the average for a specific date 
        public string avgRating(int bookID)
        {
            try
            {
                connect();
                OleDbCommand avgRating = conn.CreateCommand();
                avgRating.CommandText = "SELECT AVG(Ratings.Rating) AS Average FROM [Book] INNER JOIN [Ratings] ON Book.BookID = Ratings.bookid WHERE Book.BookID = " + bookID + "";
                OleDbDataReader avgReader = avgRating.ExecuteReader(); // calculating the average rating at 2 decimal places 
                if (avgReader != null && avgReader.HasRows)
                {
                    avgReader.Read();
                    double average = avgReader.GetDouble(0);
                    return average.ToString("f2");
                }
                else
                {
                    return "false";
                }
            }
            catch (InvalidCastException) // Used when book has not been rated 
            {
                return "No rating made";
            }
            catch (OleDbException ole)
            {
                return ole.ToString();
            }
            finally
            {
                conn.Close();
            }
        }

    }
}
