using System;
using System.Threading.Tasks;

using Payroll.Model;

namespace Payroll.Services
{
    public class ContactsService : ApiBaseService
    {
        public async Task<ContactBO> ValidateContact(string deviceToken, string phoneNumber,string email)
        {
            try
            {
                var endpoint = String.Format(Validate, phoneNumber, email,deviceToken);
                var contact = await HttpClientBase.Get<ContactBO>(endpoint);
                return contact;
            }
            catch (Exception e)
            {
                return null;
            }
          
        }

        public async Task<bool> UpdateContact(ContactBO contactbo)
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
