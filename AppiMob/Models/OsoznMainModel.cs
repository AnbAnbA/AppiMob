using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppiMob.Models
{
    public class OsoznMainModel
    {
        public OsoznMainModel(OsoznMain osoznMain) 
        {
            ID = osoznMain.ID;
            Cel = osoznMain.Cel;
            DRazum = osoznMain.DRrazum;
            Prostr = osoznMain.Prostr;
            Ocenkaemotion = osoznMain.Ocenkaemotion;
            Emotion = osoznMain.Emotion;
            Do = osoznMain.Do;
            Think = osoznMain.Think;
            Time = osoznMain.Time;
        }
        public int ID { get; set; }
        public string Cel { get; set; }
        public string DRazum { get; set; }
        public string Prostr { get; set; }
        public int Ocenkaemotion { get; set; }
        public string Emotion { get; set; }
        public string Do { get; set; }
        public string Think { get; set; }
        public string Time { get; set; }
    }
}