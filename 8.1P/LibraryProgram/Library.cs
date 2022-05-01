using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LibraryProgram
{
    public class Library
    {
        //create a list of resources
        private List<LibraryResource> _resources;

        public Library(string name)
        {
            //instantiating the _resources list
            _resources = new List<LibraryResource>();
        }

        public void AddResources(LibraryResource resource)
        {
            _resources.Add(resource); //adding passed resources to the list
        }

        public bool HasResource(string name)
        {
            foreach(LibraryResource r in _resources) //looping through the _resources list
            {
                //HasResource returns true of the name matches one of the resources in the list and if the On Loan status is false (resource not on loan)
                if(r.Name == name && r.OnLoan == false) //cross checking with the passed name
                {
                    return true;
                }
            }

            return false;
        }
    }
}
