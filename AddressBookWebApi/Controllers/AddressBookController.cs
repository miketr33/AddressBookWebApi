using AddressBookWebApi.Models;
using AddressBookWebApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AddressBookWebApi.Controllers;

[ApiController]
[Route("api/AddressBookItems")]
public class AddressBookController : ControllerBase
{
    private readonly ILogger<AddressBookController> _logger;
    private readonly List<AddressBookItem> _addressBookItems = new();
    private readonly AddressBookRepository _addressBookRepository;

    public AddressBookController(ILogger<AddressBookController> logger)
    {
        _logger = logger;
        _addressBookRepository = new AddressBookRepository();
    }

    [HttpGet]
    public IEnumerable<AddressBookItem> Get()
    {
        // TODO - Deserialise to json
        return _addressBookRepository.GetAddressBookItems();
    }

    [HttpPost]
    public IActionResult Post(AddressBookItem item)
    {
        var addressBookItems = _addressBookRepository.GetAddressBookItems();
        addressBookItems.Add(item);
        _addressBookRepository.SaveAddressBookItems(addressBookItems);
        return Ok();
    }

    [HttpPut]
    public IActionResult Put([FromBody] AddressBookItem replacementItem)
    {
        try
        {
            if (_addressBookRepository.UpdateAddressBookItem(replacementItem))
            {
                return Ok();
            }
            return NotFound($"Item with ID {replacementItem.Id} not found. Cannot update.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal Server Error: {ex.Message}");
        }
    }

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