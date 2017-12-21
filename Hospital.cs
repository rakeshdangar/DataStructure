using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    public enum Identification
    {
        /// <summary>
        /// Represents staff value
        /// </summary>
        STAFF = 1,
        /// <summary>
        /// Represents patient value
        /// </summary>
        PATIENT = 2,
    }

    public class Person
    {
        public int ID { get; private set; }
        public Identification Identity { get; private set; }
        public decimal Salary { get; private set; }
        public string PhoneNumber { get; private set; }
        public int StaffID { get; private set; }

        public static void Init()
        {
            Node tree = new Node();

            Person Staff = new Person(1, Identification.STAFF, 100.0, null);
            Person Patient = new Person(2, Identification.PATIENT, "408", 1);
            Person Patient2 = new Person(3, Identification.PATIENT, "408", 1);
            Person Patient3 = new Person(4, Identification.PATIENT, "408", 5);
            Person Staff2 = new Person(5, Identification.STAFF, 200.0, null);

            Staff.Insert(tree);
            Patient.Insert(tree);
            Patient2.Insert(tree);
            Patient3.Insert(tree);
            Staff2.Insert(tree);

            //Find particular person
            Node found = Person.FindPerson(tree, 2);

            Dictionary<int, Dictionary<int, int>> report = Person.GenerateReport(tree);

            Console.WriteLine(found.ID.ToString() + " " + found.Identity.ToString() + " " + found.Info.ToString());
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="identity"></param>
        /// <param name="info"></param>
        public Person(int id, Identification identity, object info, object staffID)
        {
            ID = id;
            Identity = identity;
            if (Identity == Identification.STAFF)
                Salary = Convert.ToDecimal(info);
            else
            {
                PhoneNumber = (string)info;
                StaffID = int.Parse(staffID.ToString()); //Must validate it to be int. Object initialization to handle error.
            }
        }

        /// <summary>
        /// Insert person (can be staff or patient)
        /// </summary>
        /// <param name="root"></param>
        public void Insert(Node root)
        {
            object info = (this.Identity == Identification.STAFF) ? (object)Salary : (object)PhoneNumber;
            Insert(root, this.ID, this.Identity, info, this.StaffID);
        }

        /// <summary>
        /// reports tracking how many times a patient has seen a particular staff. in a certain time period
        /// </summary>
        /// <returns>dictionary with patienID is key and value is dictionary of StaffID as key and number of seen as value</returns>
        public static Dictionary<int, Dictionary<int, int>> GenerateReport(Node root)
        {
            Dictionary<int, Dictionary<int, int>> report = new Dictionary<int, Dictionary<int, int>>();
            FillReport(root, report);
            return report;
        }

        /// <summary>
        /// Find a person based on Id. Person can be staff or patient
        /// </summary>
        /// <param name="root"></param>
        /// <param name="id"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        public static Node FindPerson(Node root, int id)
        {
            if (root != null)
            {
                if (root.ID == id)
                {
                    return root;
                }
                Node left = FindPerson(root.LeftNode, id);
                Node right = FindPerson(root.RightNode, id);

                if (null == left && null == right)
                    return null;
                else
                    return (null == left) ? right : left;
            }
            else return null;
        }

        private void Insert(Node root, int id, Identification identity, object info, object staffID)
        {
            Node current = root;
            while (current != null && (current.ID != id || current.Identity != identity)) //Make sure it Unique. Do not insert if it is duplicate. Duplication can be handled if required.
            {
                if (current.ID > id)
                    if (current.LeftNode == null)
                    { current.LeftNode = new Node(id, identity, info, staffID); break; }
                    else current = current.LeftNode;
                else
                    if (current.RightNode == null)
                    { current.RightNode = new Node(id, identity, info, staffID); break; }
                    else current = current.RightNode;
            }
        }


        private static void FillReport(Node root, Dictionary<int, Dictionary<int, int>> report)
        {
            Node current = root;
            if (current != null && current.Identity == Identification.PATIENT)
            {
                //Check if report already has this patien info
                if (report.ContainsKey(current.ID))
                {
                    //Check if this staff record is already added for this pateint. Increament number of times this patient has seen this staff
                    Dictionary<int, int> staff = report[current.ID];
                    if (staff.ContainsKey((int)current.StaffID))
                    {
                        ++staff[(int)current.StaffID];
                    }
                    else
                    {
                        //Create a new entry for patient to staff
                        staff.Add((int)current.StaffID, 1);
                    }

                }
                else
                {
                    //Create a new entry for patient to staff
                    Dictionary<int, int> staff = new Dictionary<int, int>();
                    staff.Add((int)current.StaffID, 1);

                    //Create a new entry for tihs patient in this report.
                    report.Add(current.ID, staff);
                }
            }

            //Traverse left
            if (current.LeftNode != null)
            {
                FillReport(current.LeftNode, report);
            }

            //Traverse left
            if (current.RightNode != null)
            {
                FillReport(current.RightNode, report);
            }
        }

    }

    public class Node
    {
        public int ID { get; private set; }
        public Identification Identity { get; private set; }
        public object Info { get; private set; }
        public object StaffID { get; private set; } //null in case person is staff.

        public Node LeftNode { get; set; }
        public Node RightNode { get; set; }

        public Node() {}

        public Node(int id, Identification identity, object info, object staffID)
        {
            ID = id;
            Identity = identity;
            Info = info;
            StaffID = staffID;
        }
    }
}
