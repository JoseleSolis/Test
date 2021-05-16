﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sims.Models;
using Sims.Models.Relations;
using Sims.Models.ViewModels;
using Sims.Models.Data;

namespace Sims.Controllers
{
    public class SimController : Controller
    {
        private IRepository repository;
        public SimController(IRepository repo)
        {
            repository = repo;
        }

        public ViewResult Profile(Guid id) => View(
            repository.Sims
            .FirstOrDefault(s => s.SimID == id));



        public ViewResult ChooseDomesticUnit(Guid id)
        {
            SimDomesticUnitViewModel simDomesticUnit = new SimDomesticUnitViewModel
            {
                Sim = repository.Sims.FirstOrDefault(s => s.SimID == id)
            };

            SimLives simLives = repository.SimLivesTable
                .FirstOrDefault(s => s.SimID == simDomesticUnit.Sim.SimID);

            simDomesticUnit.DomesticUnits = simLives == null ? repository.DomesticUnits : repository.DomesticUnits.Where(d => d.DomesticUnitID != simLives.DomesticUnitID);

            if (simLives != null)
            {
                DomesticUnit domesticUnit = repository.DomesticUnits
                    .FirstOrDefault(d => d.DomesticUnitID == simLives.DomesticUnitID);
                simDomesticUnit.CurrentDomesticUnitName = domesticUnit.Name;

            }

            return View(simDomesticUnit);
        }

        [HttpPost]
        public ActionResult ChooseDomesticUnit(SimDomesticUnitViewModel simDomesticUnit)
        {
            SimLives simLives = new SimLives
            {
                SimID = simDomesticUnit.Sim.SimID,
                DomesticUnitID = simDomesticUnit.DomesticUnitID
            };
            simLives.Sim = repository.Sims
                .FirstOrDefault(s => s.SimID == simLives.SimID);
            simLives.DomesticUnit = repository.DomesticUnits
                .FirstOrDefault(d => d.DomesticUnitID == simDomesticUnit.DomesticUnitID);

            if (ModelState.IsValid)
            {
                repository.SaveSimLives(simLives);
                TempData["message"] = $"{simLives.Sim.Name} now lives in {simLives.DomesticUnit.Name}";
                return RedirectToAction("Index");
            }
            else
            {
                //if enters here there is something wrong with the data values
                return View(simDomesticUnit);
            }
        }

        
        public ActionResult Work(Guid id)
        {
            var simJob = repository.Exercises.FirstOrDefault(s => s.SimID == id);
            
            Sim sim = repository.Sims.FirstOrDefault(s => s.SimID == id);
            Profession profession = repository.Professions.FirstOrDefault(p => p.ProfessionID == simJob.ProfessionID);
            sim.Money += simJob.Level * profession.BasicSalary;
            repository.SaveSim(sim);
            
            if (simJob.Level < 10)
                simJob.Level++;
            
            repository.SaveExercise(simJob);

            ProfessionUpgradesSkill upgrade = repository.ProfessionUpgradesSkillsTable.FirstOrDefault(p => p.ProfessionID == profession.ProfessionID);
            if (upgrade != null)
            {
                SimSkills simSkill = repository.SimSkillsTable.FirstOrDefault(s => s.SimID == sim.SimID && s.SkillID == upgrade.SkillID);
                if (simSkill == null)
                {
                    simSkill = new SimSkills
                    {
                            Sim = repository.Sims.FirstOrDefault(s => s.SimID == sim.SimID),
                            Skill = repository.Skills.FirstOrDefault(s => s.SkillID == upgrade.SkillID),
                            Points = 1
                    };
                    repository.SaveSimSkills(simSkill);
                }
                else if (simSkill.Points < 10)
                {
                        simSkill.Skill = repository.Skills.FirstOrDefault(s => s.SkillID == simSkill.SkillID);
                        simSkill.Points++;
                        repository.SaveSimSkills(simSkill);
                }
                
            }
            return RedirectToAction("Profile", new { id = id });
        }

                  
    
        public ViewResult ChooseProfession(Guid id)
        {

            SimProfessionViewModel simProfession = new SimProfessionViewModel
            {
                Sim = repository.Sims.FirstOrDefault(s => s.SimID == id)
            };
            Exercise exercise = repository.Exercises
                .FirstOrDefault(e => e.SimID == simProfession.Sim.SimID);
            simProfession.Professions = exercise == null ? repository.Professions : repository.Professions.Where(p => p.ProfessionID != exercise.ProfessionID);

            if (exercise != null)
            {
                Profession profession = repository.Professions
                    .FirstOrDefault(p => p.ProfessionID == exercise.ProfessionID);
                simProfession.CurrentProfessionName = profession.Name;
                simProfession.Level = exercise.Level;
            }

            return View(simProfession);
        }
        [HttpPost]
        public ActionResult ChooseProfession(SimProfessionViewModel simProfession)
        {
            Exercise exercise = new Exercise
            {
                SimID = simProfession.Sim.SimID,
                ProfessionID = simProfession.ProfessionID,
                Level = 1
            };
            exercise.Sim = repository.Sims
                .FirstOrDefault(s => s.SimID == exercise.SimID);
            exercise.Profession = repository.Professions
                .FirstOrDefault(p => p.ProfessionID == exercise.ProfessionID);

            if (ModelState.IsValid)
            {
                repository.SaveExercise(exercise);
                TempData["message"] = $"{exercise.Sim.Name} is now a level 1 {exercise.Profession.Name}";
                return RedirectToAction("Index");
            }
            else
            {
                //if enters here there is something wrong with the data values
                return View(simProfession);
            }
        }

        public ViewResult Skills(Guid id)
        {
            SimSkillViewModel viewModel = new SimSkillViewModel
            {
                Sim = repository.Sims.FirstOrDefault(s => s.SimID == id),
                SkillPoints = new List<SkillPoints>()
            };
            IEnumerable<SimSkills> thisSimSkills = repository.SimSkillsTable.Where(s => s.SimID == id);
            
            foreach (SimSkills skills in thisSimSkills)
                viewModel.SkillPoints.Add(new SkillPoints
                {
                    Skill = repository.Skills.FirstOrDefault(s => s.SkillID == skills.SkillID),
                    Points = skills.Points
                });
            return View(viewModel);
        }
        

        public ViewResult Activities(Guid id)
        {
            SimActivityViewModel viewModel = new SimActivityViewModel
            {
                Activities = repository.Activities,
                Sim = repository.Sims.FirstOrDefault(s => s.SimID == id)
            };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Activities(SimActivityViewModel viewModel)
        {
            viewModel.Activities = repository.Activities;
            var requirements = repository.ActivityRequiresSkillsTable
                .Where(a => a.ActivityID == viewModel.ActivityID);
      
            var skills = repository.SimSkillsTable
                .Where(s => s.SimID == viewModel.Sim.SimID);

            

            foreach (ActivityRequiresSkill requirement in requirements)
            {
                var temp = skills.FirstOrDefault(s => s.SkillID == requirement.SkillID);
                if (temp == null || temp.Points < requirement.RequiredPoints)
                {
                    string actName = repository.Activities.FirstOrDefault(a => a.ActivityID == requirement.ActivityID).Name;
                    string skiName = repository.Skills.FirstOrDefault(s => s.SkillID == requirement.SkillID).Name;
                    string pronoun = viewModel.Sim.Gender == "Masculine" ? "she" : "he";
                    
                    ViewBag.Message = $"{viewModel.Sim.Name} couldn't perform the activity {actName} " +
                        $"because {pronoun} does not fulfill {skiName} required points";
                    ViewBag.Error = true;

                    return View(viewModel);
                }
            }
            Perform performance = new Perform
            {
                Sim = repository.Sims.FirstOrDefault(s => s.SimID == viewModel.Sim.SimID),
                Activity = repository.Activities.FirstOrDefault(a => a.ActivityID == viewModel.ActivityID),
                LastPerform = DateTime.Today
            };
            repository.SavePerform(performance);
            ViewBag.Message = $"{performance.Activity.Name} successfully performed ";

            ActivityImprovesSkill improvement = repository.ActivityImprovesSkillTable.FirstOrDefault(i => i.ActivityID == performance.ActivityID);
            if (improvement != null)
            {
                SimSkills simSkill = repository.SimSkillsTable.
                    FirstOrDefault(s => s.SimID == viewModel.Sim.SimID && s.SkillID == improvement.SkillID);
                if (simSkill == null)
                {
                    simSkill = new SimSkills
                    {
                        Sim = repository.Sims.FirstOrDefault(s => s.SimID == viewModel.Sim.SimID),
                        Skill = repository.Skills.FirstOrDefault(s => s.SkillID == improvement.SkillID),
                        Points = 1
                    };
                    ViewBag.ImprovementMessage = $"{simSkill.Sim.Name} improved {simSkill.Skill.Name}'s skill points";
                    repository.SaveSimSkills(simSkill);
                }
                else if (simSkill.Points < 10)
                {
                    simSkill.Skill = repository.Skills.FirstOrDefault(s => s.SkillID == simSkill.SkillID);
                    simSkill.Points++;
                    repository.SaveSimSkills(simSkill);
                    ViewBag.ImprovementMessage = $"{simSkill.Sim.Name} improved {simSkill.Skill.Name}'s skill points";
                }     
            }

            ViewBag.Error = false;
            return View(viewModel);
        }
        
       
        
        public ViewResult FilterForm()
        {
            SimSearchFilterForm form = new SimSearchFilterForm
            {
                Professions = repository.Professions,
                Skills = repository.Skills,
                Neighborhoods = repository.Neighborhoods
            };
            return View(form);
        }
        public ActionResult List(SimSearchFilterForm form)
        {
            var simPropsCheck = repository.Sims
                .Where(s =>
                (form.Sim.Name != null && form.Sim.Name == s.Name) || (form.Sim.Name == null && s.Name != null))
                .Where(s =>
                (form.Sim.LastName != null && form.Sim.LastName == s.LastName) || (form.Sim.LastName == null && s.LastName != null))
                .ToList();

            var professionCheck = new List<Sim>();
            if (form.ProfessionID.CompareTo(Guid.Empty) != 0)
            {
                foreach (Sim sim in simPropsCheck)
                    if (repository.Exercises.FirstOrDefault(e => e.SimID == sim.SimID && e.ProfessionID == form.ProfessionID) != null)
                        professionCheck.Add(sim);
            }
            else professionCheck = simPropsCheck;

            var neighborhoodCheck = new List<Sim>();
            if (form.NeighborhoodID.CompareTo(Guid.Empty) != 0)
            {
                foreach (Sim sim in professionCheck)
                {
                    var simDomesticUnit = repository.SimLivesTable.FirstOrDefault(s => s.SimID == sim.SimID);
                    if (simDomesticUnit != null)
                    {
                        var domesticUnitNeighborhood = repository.NeighborhoodDomesticUnitsTable.FirstOrDefault(d => d.DomesticUnitID == simDomesticUnit.DomesticUnitID);
                        if (domesticUnitNeighborhood != null & domesticUnitNeighborhood.NeighborhoodID == form.NeighborhoodID)
                            neighborhoodCheck.Add(sim);
                    }
                }
            }
            else neighborhoodCheck = professionCheck;


            var bySkillPoints = new List<SimSkillPoints>();
            var simsBySkillPoints = new List<Sim>();
            if (form.SkillID.CompareTo(Guid.Empty) != 0)
            {
                foreach (Sim sim in neighborhoodCheck)
                {
                    var simPoints = repository.SimSkillsTable.FirstOrDefault(s => s.SimID == sim.SimID && s.SkillID == form.SkillID);
                    if (simPoints == null)
                        bySkillPoints.Add(new SimSkillPoints
                        {
                            Sim = sim,
                            SkillPoints = 0
                        });
                    else
                        bySkillPoints.Add(new SimSkillPoints
                        {
                            Sim = sim,
                            SkillPoints = simPoints.Points
                        });
                }
                var ordered = bySkillPoints.OrderByDescending(s => s.SkillPoints);
                foreach (var simPoints in ordered)
                    simsBySkillPoints.Add(simPoints.Sim);
                
            }
            else simsBySkillPoints = neighborhoodCheck;

            var truncatedList = new List<Sim>();
            int range = Math.Min(simsBySkillPoints.Count, form.FirstHowMany);
            for (int i = 0; i < range; i++)
                truncatedList.Add(simsBySkillPoints[i]);
            
            return View(truncatedList);                 
        }
        

        public ViewResult Index() => View(repository.Sims);
        
        public ViewResult Edit(Guid simID) =>
           View(repository.Sims
               .FirstOrDefault(s => s.SimID == simID));

        [HttpPost]
        public IActionResult Edit(Sim sim)
        {

            if (ModelState.IsValid)
            {
                repository.SaveSim(sim);
                TempData["message"] = $"{sim.Name} has been saved";
                return RedirectToAction("Index");
            }
            else
            {
                 //if enters here there is something wrong with the data values
                return View(sim);
            }
        }
        public ViewResult Create() => View("Edit", new Sim());
         
        [HttpPost]
        public IActionResult Delete(Guid simID)
        {
            Sim deletedSim = repository.DeleteSim(simID);
            if (deletedSim != null)
            {
                
                TempData["message"] = $"{deletedSim.Name} was deleted";
                
            }
            return RedirectToAction("Index");
        }
        
    }
}
