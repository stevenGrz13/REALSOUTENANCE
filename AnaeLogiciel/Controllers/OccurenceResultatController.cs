using AnaeLogiciel.Data;
using AnaeLogiciel.Models;
using Microsoft.AspNetCore.Mvc;

namespace AnaeLogiciel.Controllers;

public class OccurenceResultatController : Controller
{
    private readonly ApplicationDbContext _context;

    public OccurenceResultatController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult deleteResultat(int idoccurenceresultat)
    {
        OccurenceResultat or = _context.OccurenceResultat
            .First(a => a.Id == idoccurenceresultat);
        or.IsSupp = true;
        _context.SaveChanges();
        int idprojet = HttpContext.Session.GetInt32("idprojet").GetValueOrDefault();
        return RedirectToAction("Details", "Projet", new {idprojet = idprojet});
    }

    public IActionResult VersTableauDeBord(int idoccurenceresultat)
    {
        List<DateRealisationActivite> listedate = new List<DateRealisationActivite>();
        List<OccurenceActivite> liste = _context.OccurenceActivite
            .Where(a => a.IdOccurenceResultat == idoccurenceresultat)
            .ToList();
        foreach (var v in liste)
        {
            DateRealisationActivite d = _context.DateRealisationActivite
                .FirstOrDefault(a => a.IdOccurenceActivite == v.Id);
            if (d != null)
            {
                listedate.Add(d);
            }
        }
        ViewData["listeactivite"] = liste;
        ViewData["listedate"] = listedate;
        return View("TableauDeBordResultat");
    }
}