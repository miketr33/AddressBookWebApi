using AddressBookWebApi.Models;

namespace AddressBookWebApi.Repositories;

/// <summary>
/// The address book repository.
/// </summary>
public interface IAddressBookRepository
{
    /// <summary>
    /// Gets all address book items in file.
    /// </summary>
    /// <returns>A list of all address book items from the flat file.</returns>
    List<AddressBookItem> GetAddressBookItems();
    
    /// <summary>
    /// Saves items to file (destructive).
    /// </summary>
    /// <param name="addressBookItems">Items to write to file.</param>
    void SaveAddressBookItems(List<AddressBookItem> addressBookItems);
    
    /// <summary>
    /// Updates an address book item. 
    /// </summary>
    /// <param name="updatedItem">The item that will overwrite and existing one.</param>
    /// <returns><see cref="bool"/> to indicate success.</returns>
    bool UpdateAddressBookItem(AddressBookItem updatedItem);
    
    /// <summary>
    /// Deletes an address book item.
    /// </summary>
    /// <param name="id">The id of the id you wish to delete.</param>
    /// <returns><see cref="bool"/> to indicate success.</returns>
    bool DeleteAddressBookItem(string id);
}