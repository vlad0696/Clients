using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clients.Models
{

    class DropdownValues
    {

        public int value { get; set; }
        public string name { get; set; }

        public DropdownValues(int Value, string Name)
        {
            this.value = Value;
            this.name = Name;
        }
    }
    class DropDown
    {
        public bool success = true;
        public List<DropdownValues> results { get; set; }
        public DropDown(List<DropdownValues> list)
        {
            this.results = list;
        }
    }

    public class AjaxResponse
    {
        public AjaxResponse()
        {
            Success = true;
            Data = new List<object>();
        }

        public AjaxResponse(Exception exception)
            : this()
        {
            Success = false;
            Errors = new[] { exception.Message };
        }

        public AjaxResponse(object data)
            : this()
        {
            Data = data;
        }

        public bool Success
        {
            get; set;
        }
        public object Data
        {
            get; set;
        }
        public string[] Errors
        {
            get; set;
        }
    }
}