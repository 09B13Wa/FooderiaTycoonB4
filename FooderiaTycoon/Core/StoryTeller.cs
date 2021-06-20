using System;
using System.Collections.Generic;
using FooderiaTycoon.Core;
using FooderiaTycoon.Tools;

namespace FooderiaTycoon
{
    public enum StoryTellerBase
    {
        CASANDRA_CLASSIC,
        PHOEBE_CHILLAX,
        RANDY_RANDOM
    }
    
    public class StoryTeller
    {
        private Difficulty _difficultySetting;
        private HashSet<Event> _events;
        private FooderiaTycoon _fooderiaTycoon;

        public StoryTeller(FooderiaTycoon fooderiaTycoon)
        {
            this._fooderiaTycoon = fooderiaTycoon;
        }

        public StoryTeller(FooderiaTycoon fooderiaTycoon, StoryTellerBase storyTellerBase, HashSet<Event> events)
        {
            throw new NotImplementedException();
        }

        public StoryTeller(FooderiaTycoon fooderiaTycoon, Difficulty difficultySetting, HashSet<Event> events)
        {
            _difficultySetting = difficultySetting;
            _events = events;
        }

        private void AddaptToStoryTeller(StoryTellerBase storyTellerBase)
        {
            throw new NotImplementedException();
        }

        public void AddEvent(Event @event)
        {
            _events.Add(@event);
        }

        public void RemoveEvent(Event @event)
        {
            _events.Remove(@event);
        }

        public Event GetEvent(Event @event)
        {
            bool foundEvent = false;
            Event foundEventObj = null;
            foreach (Event eventLoop in _events)
            {
                if (foundEvent)
                    break;
                if (@event == eventLoop)
                {
                    foundEvent = true;
                    foundEventObj = eventLoop;
                }
            }

            return foundEventObj;
        }

        public void PlayTurn()
        {
            throw new NotImplementedException();
        }
    }

    public enum BaseDifficulty
    {
        PEACEFUL,
        COMMUNITY_BUILDER,
        ADVENTURE_STORY,
        STRIVE_TO_SURVIVE,
        BLOOD_AND_DUST,
        LOSING_IS_FUN,
        CUSTOM
    }

    public enum Reload
    {
        ANYTIME,
        RELOAD_ANYTIME
    }

    public struct Difficulty
    {
        private Percentage _threatScale;
        private bool _majorThreats;
        private bool _minorThreats;
        private bool _introThreats;
        private bool _criminalsHuntPeople;
        private bool _extremeWeather;

        private Percentage _ressourceYield;
        private Percentage _constructionRate;
        private Percentage _bootcheringRate;
        private Percentage _researchSpeed;
        private Percentage _questRewards;

        private Percentage _tradePriceDisadvantage;
        private int _generalMood;
        private Percentage _foodPoisonChance;
        private Percentage _animalRevengeChance;
        private Percentage _infectionChance;
        private Percentage _diseaseFrequency;
        private Percentage _spawningRate;

        public Difficulty(BaseDifficulty baseDifficulty = BaseDifficulty.ADVENTURE_STORY)
        {
            throw new NotImplementedException();
        }

        public Difficulty(Percentage threatScale, bool majorThreats, bool minorThreats, bool introThreats, 
            bool criminalsHuntPeople, bool extremeWeather, Percentage ressourceYield, Percentage constructionRate, 
            Percentage bootcheringRate, Percentage researchSpeed, Percentage questRewards, Percentage tradePriceDisadvantage, 
            int generalMood, Percentage foodPoisonChance, Percentage animalRevengeChance, Percentage infectionChance, 
            Percentage diseaseFrequency, Percentage spawningRate)
        {
            _threatScale = threatScale;
            _majorThreats = majorThreats;
            _minorThreats = minorThreats;
            _introThreats = introThreats;
            _criminalsHuntPeople = criminalsHuntPeople;
            _extremeWeather = extremeWeather;
            _ressourceYield = ressourceYield;
            _constructionRate = constructionRate;
            _bootcheringRate = bootcheringRate;
            _researchSpeed = researchSpeed;
            _questRewards = questRewards;
            _tradePriceDisadvantage = tradePriceDisadvantage;
            _generalMood = generalMood;
            _foodPoisonChance = foodPoisonChance;
            _animalRevengeChance = animalRevengeChance;
            _infectionChance = infectionChance;
            _diseaseFrequency = diseaseFrequency;
            _spawningRate = spawningRate;
        }

        public Percentage ThreatScale => _threatScale;

        public bool MajorThreats => _majorThreats;

        public bool MinorThreats => _minorThreats;

        public bool IntroThreats => _introThreats;

        public bool CriminalsHuntPeople => _criminalsHuntPeople;

        public bool ExtremeWeather => _extremeWeather;

        public Percentage RessourceYield => _ressourceYield;

        public Percentage ConstructionRate => _constructionRate;

        public Percentage BootcheringRate => _bootcheringRate;

        public Percentage ResearchSpeed => _researchSpeed;

        public Percentage QuestRewards => _questRewards;

        public Percentage TradePriceDisadvantage => _tradePriceDisadvantage;

        public int GeneralMood => _generalMood;

        public Percentage FoodPoisonChance => _foodPoisonChance;

        public Percentage AnimalRevengeChance => _animalRevengeChance;

        public Percentage InfectionChance => _infectionChance;

        public Percentage DiseaseFrequency => _diseaseFrequency;

        public Percentage SpawningRate => _spawningRate;
    }
}