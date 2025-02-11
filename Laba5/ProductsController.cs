namespace Laba5;
using BLL.DTO;
using BLL.Interfaces;
using DAL.models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Xml.Linq;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ISearchByName<ProductDTO> _searchByName;
    private readonly ISearchByPrice<ProductDTO> _searchByPrice;
    private readonly IService<ProductDTO> _productService;
    private readonly Ilaba5Service<ProductDTO> _laba5service;


    public ProductsController(
        ISearchByName<ProductDTO> searchByName,
        ISearchByPrice<ProductDTO> searchByPrice,
        Ilaba5Service<ProductDTO> laba5service,
        IService<ProductDTO> productService)
    {
        _laba5service = laba5service;
        _productService = productService;
        _searchByName = searchByName;
        _searchByPrice = searchByPrice;
    }

    [HttpGet("search/price/{price}")]
    public ActionResult<List<ProductDTO>> SearchByPrice(int price)
    {
        var product = _searchByPrice.SearchByPrice(price);
        if (product == null) return NotFound();
        return Ok(product);
    }

    [HttpGet("search/name/{name}")]
    public ActionResult<List<ProductDTO>> SearchByName(string name)
    {
        var product = _searchByName.SearchByName(name);
        if (product == null) return NotFound();
        return Ok(product);
    }

    [HttpGet("search/laba5/{name}")]
    public ActionResult<List<ProductDTO>> GetProductsByCategoryName(string name)
    {
        var product = _laba5service.GetProductsByCategoryName(name);
        if (product == null) return NotFound();
        return Ok(product);
    }

    [HttpGet]
    public ActionResult<List<ProductDTO>> GetAll()
    {
        return Ok(_productService.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult<ProductDTO> GetById(int id)
    {
        var product = _productService.FindById(id);
        if (product == null) return NotFound();
        return Ok(product);
    }

    [HttpPost]
    public ActionResult Add([FromBody] ProductDTO productDto)
    {
        _productService.Add(productDto);
        return CreatedAtAction(nameof(GetById), new { id = productDto.ProductId }, productDto);
    }

    [HttpPut("{id}")]
    public ActionResult Update(int id, [FromBody] ProductDTO productDto)
    {
        if (id != productDto.ProductId) return BadRequest();
        _productService.Update(productDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        _productService.DeleteById(id);
        return NoContent();
    }
}
