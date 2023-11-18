using AnaeLogiciel.Data;
using AnaeLogiciel.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AnaeLogiciel.Controllers;

public class StatistiqueController : Controller
{
    private readonly ApplicationDbContext _context;

    public StatistiqueController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult CalculStatistique()
    {
        List<Artisants> liste = _context.Artisants.ToList();
        double nbFemme = liste.Where(a => a.IdGenre == 2).Count();
        double nbHomme = liste.Where(a => a.IdGenre == 1).Count();
        double pourcentagefemme = (nbFemme * 100) / liste.Count;
        double pourcentagehomme = (nbHomme * 100) / liste.Count;
        PourcentageHommeFemme p = new PourcentageHommeFemme()
        {
            PourcentageHomme = (int) pourcentagehomme,
            PourcentageFemme = (int) pourcentagefemme
        };
        ViewData["pourcentage"] = p;
        return View("~/Views/Statistique/StatistiqueHommeFemme.cshtml");
    }

    public IActionResult StatistiqueRepartition()
    {
        List<Projet> listeprojet = _context.Projet.ToList();
        foreach (var v in listeprojet)
        {
             v.nbSite = _context.Site.Where(a => a.IdProjet == v.Id).ToList().Count;
        }
        ViewData["projet"] = listeprojet;
        return View("~/Views/Statistique/StatistiqueRepartition.cshtml");
    }

    public IActionResult StatistiqueNombreDeProjetParAn()
    {
        List<StatProjetAnnee> liste = new List<StatProjetAnnee>();
        int[] table = new int[7];
        int annee = 2017;
        for (int i = 0; i < table.Length; i++)
        {
            StatProjetAnnee stat = new StatProjetAnnee()
            {
                annee = annee,
                nbprojet = _context.Projet.Where(a => a.DateDebutPrevision.Year == annee).Count()
            };
            liste.Add(stat);
            annee++;
        }
        ViewData["nbprojet"] = liste;
        return View("~/Views/Statistique/StatistiqueNombreProjetParAn.cshtml");
    }
}