using System.Text.Json;
using AddressBookWebApi.Models;

namespace AddressBookWebApi.Repositories;

/// <summary>
/// Address book repository class, implements <see cref="IAddressBookRepository"/>.
/// </summary>
public class AddressBookRepository : IAddressBookRepository
{
    /// <summary>
    /// The JSON flat file where the address book stores all its data (as per spec).
    /// </summary>
    private const string FilePath = "addressBookData.json";

    /// <summary>
    /// Gets all address book items in file.
    /// </summary>
    /// <returns>A list of all address book items from the flat file.</returns>
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

    /// <summary>
    /// Saves items to file (destructive).
    /// </summary>
    /// <param name="addressBookItems">Items to write to file.</param>
    public void SaveAddressBookItems(List<AddressBookItem> addressBookItems)
    {
        var json = JsonSerializer.Serialize(addressBookItems, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(FilePath, json);
    }

    /// <summary>
    /// Updates an address book item. 
    /// </summary>
    /// <param name="updatedItem">The item that will overwrite and existing one.</param>
    /// <returns><see cref="bool"/> to indicate success.</returns>
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

    /// <summary>
    /// Deletes an address book item.
    /// </summary>
    /// <param name="id">The id of the id you wish to delete.</param>
    /// <returns><see cref="bool"/> to indicate success.</returns>
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
