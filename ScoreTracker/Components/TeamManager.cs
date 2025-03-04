﻿using Microsoft.EntityFrameworkCore;
using ScoreTracker.Models;

namespace ScoreTracker.Components
{
    public interface ITeamManager
    {
        void AddTeam(string name, List<User> Users);
        void RemoveTeam(int id);
        void EditTeam(Team team);
        List<Team> GetAll();
        Team GetTeam(int id);
    }

    public class TeamManager : ITeamManager
    {
        private readonly DataContext context;

        public TeamManager(DataContext context)
        {
            this.context = context;
        }

        public void AddTeam(string name, List<User> Users)
        {
            var team = new Team();

            team.Name = name;

            team.Users = Users;

            context.Teams.Add(team);

            context.SaveChanges();
        }

        public void RemoveTeam(int id)
        {
            var team = context.Teams.FirstOrDefault(x => x.Id == id);

            if (team != null)
            {
                context.Teams.Remove(team);
                context.SaveChanges();

                return;
            }

            throw new Exception("Team not found");
        }

        public List<Team> GetAll()
        {
            return context.Teams.Include(o => o.Users).ToList();
        }

        public Team GetTeam(int id)
        {
            return context.Teams.Include(x => x.Users).FirstOrDefault(x => x.Id.Equals(id));
        }

        public void EditTeam(Team team)
        {
            context.Teams.Update(team);

            context.SaveChanges();
        }
    }
}
