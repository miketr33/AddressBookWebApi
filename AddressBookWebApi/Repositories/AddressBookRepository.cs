using System.Text.Json;
using AddressBookWebApi.Models;

namespace AddressBookWebApi.Repositories;


    public class AddressBookRepository
    {
        private const string FilePath = "addressBookData.json";

        public List<AddressBookItem> GetAddressBookItems()
        {
            if (File.Exists(FilePath))
            {
                var json = File.ReadAllText(FilePath);
                return JsonSerializer.Deserialize<List<AddressBookItem>>(json);
            }
            else
            {
                return new List<AddressBookItem>();
            }
        }

        public void SaveAddressBookItems(List<AddressBookItem> addressBookItems)
        {
            var json = JsonSerializer.Serialize(addressBookItems, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FilePath, json);
        }
        
        public bool UpdateAddressBookItem(AddressBookItem updatedItem)
        {
            var addressBookItems = GetAddressBookItems();
            var existingItem = addressBookItems.FirstOrDefault(item => item.Id == updatedItem.Id);

            if (existingItem != null)
            {
                existingItem.FirstName = updatedItem.FirstName;
                existingItem.LastName = updatedItem.LastName;
                existingItem.Phone = updatedItem.Phone;
                existingItem.Email = updatedItem.Email;

                SaveAddressBookItems(addressBookItems);
                return true;
            }

            return false;
        }

        public bool DeleteAddressBookItem(string id)
        {
            var addressBookItems = GetAddressBookItems();
            var itemToDelete = addressBookItems.FirstOrDefault(item => item.Id == id);

            if (itemToDelete != null)
            {
                addressBookItems.Remove(itemToDelete);
                SaveAddressBookItems(addressBookItems);
                return true;
            }

            return false;
        }
    }
