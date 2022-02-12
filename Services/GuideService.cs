using EDPFinal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDPFinal.Services
{
    public class GuideService
    {
        private GuidesDbContext _context;
        public GuideService(GuidesDbContext dbContext)
        {
            _context = dbContext;

        }

        public List<Guides> GetAllGuides()
        {
            List<Guides> AllGuides = new List<Guides>();
            AllGuides = _context.Guides.ToList();
            return AllGuides;
        }
        private bool GuideExists(int id)
        {
            return _context.Guides.Any(e => e.guideID == id);
        }
        public bool AddGuide(Guides newguide)
        {
            if (GuideExists(newguide.guideID))
            {
                return false;
            }
            _context.Add(newguide);
            _context.SaveChanges();
            return true;
        }
        public bool UpdateGuide(Guides theguide)
        {
            bool updated = true;
            _context.Attach(theguide).State = EntityState.Modified;
            try
            {
                _context.SaveChanges();
                updated = true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GuideExists(theguide.guideID))
                {
                    updated = false;
                }
                else
                {
                    throw;
                }
            }
            return updated;
        }
        public bool DeleteGuide(Guides theguide)
        {
            bool deleted = true;
            try
            {
                _context.Remove(theguide);
                _context.SaveChanges();
                deleted = true;


            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GuideExists(theguide.guideID))
                {
                    deleted = false;
                }
                else
                {
                    throw;
                }
            }
            return deleted;

        }
        public Guides GetGuideById(int id)
        {
            var cor = _context.Guides.SingleOrDefault(o => o.guideID == id);
            return cor;
            //Guides theGuide = _context.Guides.Where(e => e.guideID == id).FirstOrDefault();
            //return theGuide;
        }
    }
}
