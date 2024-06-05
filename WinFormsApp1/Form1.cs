using System.Data;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {

        DataSet ds;
        DataTable dt;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.ds != null)
                this.ds.Reset();
            else
                this.ds = new DataSet();

            this.ds.ReadXml(@"D:\ex2\table2.xml");

            this.dataGridView1.DataSource = this.ds.Tables[0];

        }

        //Convert Xml to DataTable in C#
        // https://www.iditect.com/faq/csharp/convert-xml-to-datatable-in-c.html
        private void button2_Click(object sender, EventArgs e)
        {
            string xmlData = @"<Root>
                            <Person>
                                <Name>John Doe</Name>
                                <Age>30</Age>
                            </Person>
                            <Person>
                                <Name>Jane Smith</Name>
                                <Age>25</Age>
                            </Person>
                        </Root>";

            DataSet dataSet = new DataSet();
            using (StringReader stringReader = new StringReader(xmlData))
            {
                dataSet.ReadXml(stringReader);
            }

            // Assuming you have a single DataTable in the DataSet, you can access it like this:
            DataTable dataTable = dataSet.Tables[0];

            // my
            this.dataGridView1.DataSource = dataTable;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.ds != null)

                this.ds.Reset();
            else
                this.ds = new DataSet();

            this.ds.ReadXmlSchema(@"D:\ex2\VisitingBeremenPacient.xsd");

            DataRow workRow = this.ds.Tables[0].NewRow();
            workRow["id"] = "111111";
            workRow["fam"] = "fam";
            workRow["name"] = "name";
            workRow["dr"] = "2010-12-11";
            workRow["snils"] = "111-111-111 11";
            workRow["result"] = "www";
            workRow["datevisit"] = "2010-11-11";
            this.ds.Tables[0].Rows.Add(workRow);

            this.ds.ReadXml(@"D:\ex2\VisitingBeremenPacient.xml");

            this.dataGridView1.DataSource = this.ds.Tables[0];


        }



    }
}
