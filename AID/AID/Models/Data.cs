using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AID.Models;

namespace AID.Models
{
    public static class Data
    {
        public static List<login> GetLogin()
        {
            using (var db = new DContext())
            {
                return db.login.ToList();
            }
        }
        public static void UpdateUserInfo(int infoid, string Username, string Password)
        {
            using (var db = new DContext())
            {
                login login = db.login.Find(infoid);
                login.username = Username;
                login.password = Password;
                db.SaveChanges();
            }
        }
        public static void AddCharity(charity charity)
        {
            using (var db = new DContext())
            {
                db.Add(charity);
                db.SaveChanges();
            }
        }
        public static List<charity> GetCharities()
        {
            using (var db = new DContext())
            {
                return db.charity.ToList();
            }
        }
        public static void DeleteCharity(int charityid)
        {
            using (var db = new DContext())
            {
                charity charity = db.charity.Find(charityid);
                db.Remove(charity);
                db.SaveChanges();
            }
        }
        public static void UpdateCharity(int CharId, string CharTitle)
        {
            using (var db = new DContext())
            {
                charity Char = db.charity.Find(CharId);
                Char.title = CharTitle;
                db.SaveChanges();
            }
        }
        public static List<charity> SearchCharity(string str)
        {
            using (var db = new DContext())
            {
                var cha = db.charity.Where(b => b.title.Contains(str)).ToList();
                return cha;
            }
        }
        public static List<config> GetConfigs()
        {
            using (var db = new DContext())
            {
                return db.configs.ToList();
            }
        }
        public static void UpdateConfigs(int conId, string cwd, string cyd, string ost, string vp, string vc)
        {
            using (var db = new DContext())
            {
                config con = db.configs.Find(conId);
                con.CloseWeekDays = cwd;
                con.CloseYearDays = cyd;
                con.OfficeStartTime = ost;
                con.VisitPeriod = vp;
                con.VisitCount = vc;
                db.SaveChanges();
            }
        }
        public static List<patient> SearchPatient(string str)
        {
            using (var db = new DContext())
            {
                var pat = 
                    db.
                    patients.
                    Where(b => b.Name.Contains(str) ||
                               b.NationalCode.StartsWith(str)).ToList();
                return pat;
            }
        }
        public static List<patient> GetPatients()
        {
            using (var db = new DContext())
            {
                return db.patients.ToList();
            }
        }
        public static void AddPatients(patient patient)
        {
            using (var db = new DContext())
            {
                db.Add(patient);
                db.SaveChanges();
            }
        }
        public static void UpdatePatients(int id, string name, string nationalcode, string phone, string address)
        {
            using (var db = new DContext())
            {
                patient pat = db.patients.Find(id);
                pat.Name = name;
                pat.NationalCode = nationalcode;
                pat.PhoneNumber = phone;
                pat.Address = address;
                db.SaveChanges();
            }
        }
        public static void DeletePatients(int patId)
        {
            using (var db = new DContext())
            {
                patient pat = db.patients.Find(patId);
                db.Remove(pat);
                db.SaveChanges();
            }
        }
        public static List<visit> GetVisits()
        {
            using (var db = new DContext())
            {
                return db.visits.ToList();
            }
        }
        public static void AddVisits(visit visit)
        {
            using (var db = new DContext())
            {
                db.Add(visit);
                db.SaveChanges();
            }
        }
        public static void UpdateVisits(int id, int patid, int charid, string visittime, string disvalue, int insur, int status, DateTime visitdate)
        {
            using(var db = new DContext())
            {
                var vis = db.visits.Find(id);
                vis.patientId = patid;
                vis.charityId = charid;
                vis.visitTime = visittime;
                vis.discountValue = disvalue;
                vis.insurance = insur;
                vis.status = status;
                vis.visitDateTime = visitdate;
                db.SaveChanges();
            }
        }
        public static void DeleteVisits(int id)
        {
            using( var db = new DContext())
            {
                visit vis= db.visits.Find(id);
                db.Remove(vis);
                db.SaveChanges();
            }
        }
    }
}
