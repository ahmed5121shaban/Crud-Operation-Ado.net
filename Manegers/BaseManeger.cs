using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manegers
{
    public class BaseManeger<T> : DataBaseHelper where T : class ,new()
    {
        public BaseManeger() : base("DB") { }

        public virtual void Add(T item)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            foreach (var prop in item.GetType().GetProperties())
            {
                if (prop.Name == "ID")
                    continue;
                
                dict.Add(prop.Name,prop.GetValue(item));
            }
            base.Open();
            base.ExecuteNoNQuery($"sp_add_{item.GetType().Name}", dict);
            base.Close();

        }
        public virtual IEnumerable<T> getAll()
        {
            T Obj = new T();
            DataSet dataSet = base.ExecuteQuery($"sp_get_All_{Obj.GetType().Name}");
            for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
            {
                T data = new T();
                foreach (var item in data.GetType().GetProperties())
                {
                    item.SetValue(data, dataSet.Tables[0].Rows[i][item.Name]);
                }
                yield return data;
            }
        }

        public virtual T getById(int _ID)
        {
            T Obj = new T();
            DataSet dataSet = base.ExecuteQuery($"sp_get_{Obj.GetType().Name}_by_id", new Dictionary<string, object> { { "@ID", _ID } });
            foreach (var prop in Obj.GetType().GetProperties())
            {
                prop.SetValue(Obj, dataSet.Tables[0].Rows[0][prop.Name]);
            }

            return Obj;
        }

        public virtual bool Delete(T item)
        {
            Dictionary<string,object> dict = new Dictionary<string,object>();
            foreach (var prop in item.GetType().GetProperties())
            {
                if (prop.Name == "ID")
                    dict.Add(prop.Name,prop.GetValue(item));
            }
            base.Open();
            return base.ExecuteNoNQuery($"sp_Delete_{item.GetType().Name}", dict);



        }
        public virtual bool Update(T item)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            foreach (var prop in item.GetType().GetProperties())
            {
                dict.Add(prop.Name,prop.GetValue(item));
            }
            base.Open();
            return base.ExecuteNoNQuery($"sp_Update_{item.GetType().Name}", dict);


        }



    }
}

