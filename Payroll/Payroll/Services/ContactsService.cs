using System;
using System.Threading.Tasks;

using Payroll.Model;

namespace Payroll.Services
{
    public class ContactsService : ApiBaseService
    {
        public async Task<Contact> ValidateContact(string deviceToken, string phoneNumber)
        {
            try
            {
                var endpoint = String.Format(GetContacts, deviceToken, phoneNumber);
                var contact = await HttpClientBase.Get<Contact>(endpoint);
                return contact;
            }
            catch (Exception e)
            {
                return null;
            }
          
        }

        public async Task<bool> UpdateContact(Contact contactbo)
        {
            try
            {
                var endpoint = String.Format(InsertContact, contactbo.EntryID);
                var result = await HttpClientBase.Put(endpoint, contactbo);
                return result;
            }
            catch (Exception e)
            {
                return false;
            }

        }
    }
}
