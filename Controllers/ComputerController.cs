using Microsoft.AspNetCore.Mvc;
using MvcLabManager.Models;

namespace MvcLabManager.Controllers;

public class ComputerController : Controller
{
    private readonly LabManagerContext _context;

    public ComputerController(LabManagerContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View(_context.Computers);
    }

    public IActionResult Show(int id)
    {
        Computer computer = _context.Computers.Find(id);

        if(computer == null)
        {
            return NotFound();
        }

        return View(computer);
    }

    public IActionResult Cadastro()
    {
        return View();
    }

    public IActionResult Cadastrando([FromForm] int id, [FromForm] string ram, [FromForm] string processor)
    {
        if(_context.Computers.Find(id) != null)
        {
            return View(id);
        }
        else
        {
             _context.Computers.Add(new Computer(id, ram, processor));
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    }

    public IActionResult Update([FromForm] int id, [FromForm] string ram, [FromForm] string processor)
    {
         Computer computer = _context.Computers.Find(id);

        if(computer != null)
        {
            computer.Ram = ram;
            computer.Processor = processor;
            _context.Computers.Update(computer);
            _context.SaveChanges();
        }
        return RedirectToAction("Index");
    }

    public IActionResult Atualizacao(int id)
    {
        Computer computer = _context.Computers.Find(id);

        if(computer == null)
        {
            return NotFound();
        }

        return View(computer);
    }

    public IActionResult Delete(int id)
    {
        _context.Computers.Remove(_context.Computers.Find(id));
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

}
