using AddressBookWebApi.Models;
using AddressBookWebApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AddressBookWebApi.Controllers;

/// <summary>
/// The address book controller class. Used for all address book operations. 
/// </summary>
[ApiController]
[Route("api/AddressBookItems")]
[Produces("application/json")]
public class AddressBookController : ControllerBase
{
    private readonly IAddressBookRepository _addressBookRepository;

    public AddressBookController(IAddressBookRepository addressBookRepository)
    {
        _addressBookRepository = addressBookRepository;
    }

    /// <summary>
    /// Gets all items in the address book.
    /// </summary>
    /// <returns>A list of <see cref="AddressBookItem"/></returns>
    [HttpGet]
    public IEnumerable<AddressBookItem> Get()
    {
        return _addressBookRepository.GetAddressBookItems();
    }

    /// <summary>
    /// Adds a new address book item in the address book.
    /// </summary>
    /// <param name="item">The item you wish to add.</param>
    /// <returns><see cref="IActionResult"/></returns>
    [HttpPost]
    public IActionResult Post(AddressBookItem item)
    {
        var addressBookItems = _addressBookRepository.GetAddressBookItems();
        addressBookItems.Add(item);
        _addressBookRepository.SaveAddressBookItems(addressBookItems);
        return Ok();
    }

    /// <summary>
    /// Updates an address book item by overwriting all values for that item.
    /// </summary>
    /// <param name="replacementItem">The replacement item.</param>
    /// <returns><see cref="IActionResult"/></returns>
    [HttpPut]
    public IActionResult Put([FromBody] AddressBookItem replacementItem)
    {
        if (_addressBookRepository.UpdateAddressBookItem(replacementItem))
        {
            return Ok();
        }
        return NotFound($"Item with ID {replacementItem.Id} not found. Cannot update.");
    }

    /// <summary>
    /// Deletes an address book item using the id.
    /// </summary>
    /// <param name="id">The id number (int) of the item to delete.</param>
    /// <returns><see cref="IActionResult"/></returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        try
        {
            if (_addressBookRepository.DeleteAddressBookItem(id))
            {
                return Ok();
            }
            return NotFound($"Item with ID {id} not found");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal Server Error: {ex.Message}");
        }
    }
}