using Firebase1.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Firebase1.Database.ContentType;

namespace Firebase1.Storage
{
    public class Storage
    {
        #region Properties

        private string url;
        private Assemble assemble;

        #endregion

        #region Constructor

        public Storage(string id)
        {
            //https://firebasestorage.googleapis.com/v0/b/noar-7a7dc.appspot.com/o?uploadType=media&name=crew
            url = "https://firebasestorage.googleapis.com/v0/b/" + id + ".appspot.com/";
            assemble = new Assemble();
        }

        #endregion

        public Child Child(string path)
        {
            return new Child(url, path);
        }

        public Assemble Assemble { get { return assemble; } }
    }

}
