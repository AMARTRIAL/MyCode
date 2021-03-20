/// <copyright>
/// Developed by Amar Singh
/// </copyright>

namespace ASB.ConsoleApplications
{
    using Microsoft.Xrm.Sdk;
    using Microsoft.Xrm.Sdk.Query;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class CommonBO
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="fieldName"></param>
        /// <param name="fieldValue"></param>
        /// <returns>All Fields</returns>
        public Entity GetByName(string entity, string fieldName, string fieldValue)
        {
            return GetByName(entity, fieldName, fieldValue, new string[] { });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="fieldName"></param>
        /// <param name="fieldValue"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        public Entity GetByName(string entity, string fieldName, string fieldValue, string[] fields)
        {
            Entity _entity = null;
            QueryExpression query = this.BuildQuery(entity, fieldName, fieldValue);
            if (fields.Length == 0)
            {
                query.ColumnSet.AllColumns = true;
            }
            else query.ColumnSet.AddColumns(fields);

            //EntityCollection entities = organizationService.RetrieveMultiple(query);
            //if (entities.Entities.Count == 1)
            //{
            //    _entity = entities[0];
            //}
            return _entity;
        }

       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="fieldName"></param>
        /// <param name="fieldValue"></param>
        /// <returns></returns>
        public QueryExpression BuildQuery(string entity, string fieldName, string fieldValue)
        {
            Guid _id = Guid.Empty;
            QueryExpression query = new QueryExpression();
            query.EntityName = entity;
            query.NoLock = true;

            ConditionExpression c1 = new ConditionExpression();
            c1.AttributeName = fieldName;
            c1.Operator = ConditionOperator.Equal;
            c1.Values.Add(fieldValue);
            FilterExpression f1 = new FilterExpression();
            f1.Conditions.Add(c1);
            query.Criteria.AddFilter(f1);
            return query;
        }

        /// <summary>
        /// Returns multiple rows based on condition..
        /// </summary>
        /// <param name="fetchQuery"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public EntityCollection RetreiveMultiple(IOrganizationService organizationService, String fetchQuery, String[] args)
        {
            if (args != null)
                return organizationService.RetrieveMultiple(new FetchExpression(String.Format(fetchQuery, args)));

            return organizationService.RetrieveMultiple(new FetchExpression(String.Format(fetchQuery)));
        }
    }
}
