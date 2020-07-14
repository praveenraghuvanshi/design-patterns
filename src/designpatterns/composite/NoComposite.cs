using System;
using System.Collections.Generic;

namespace composite
{
    class NoComposite
    {
        public void Run()
        {
            /*
             * Project
             *      |
             *      |-----Epic-1
             *      |       |
             *      |       |----US-1(5)
             *      |       |
             *      |       |----US-2(8)
             *      |
             *      |-----Epic-2
             *      |       |
             *      |       |----US-3(3)
             *      |       |
             *      |       |----US-4(8)
             *      |       
             *      |
             *      |----US-5(2)
             *      |
             *      |----US-6(8)
             *
             * Total story points in a project: 34
             */

            // User stories
            var us1 = new UserStory(5);
            var us2 = new UserStory(8);
            var us3 = new UserStory(3);
            var us4 = new UserStory(8);
            var us5 = new UserStory(2);
            var us6 = new UserStory(8);

            // Epics
            var epic1 = new Epic();
            epic1.AddUserStory(us1);
            epic1.AddUserStory(us2);

            var epic2 = new Epic();
            epic2.AddUserStory(us3);
            epic2.AddUserStory(us4);

            // Project
            var project = new Project();
            project.AddEpic(epic1);
            project.AddEpic(epic2);
            project.AddUserStory(us5);
            project.AddUserStory(us6);

            // Calculate total sum, it should be 34
            var result = project.CalculateStoryPoints();
            Console.WriteLine($"Total number of story points in a Project is {result}");
        }

        class UserStory
        {
            private int _storyPoints;

            public UserStory(int storyPoints)
            {
                _storyPoints = storyPoints;
            }

            public int CalculateStoryPoints()
            {
                return _storyPoints;
            }
        }

        class Epic
        {
            private readonly List<UserStory> _userStories;
            private int _storyPoints;

            public Epic()
            {
                _userStories = new List<UserStory>();
            }

            public int CalculateStoryPoints()
            {
                foreach (var userStory in _userStories)
                {
                    _storyPoints += userStory.CalculateStoryPoints();
                }

                return _storyPoints;
            }

            public void AddUserStory(UserStory userStory)
            {
                _userStories.Add(userStory);
            }

            public void RemoveUserStory(UserStory userStory)
            {
                _userStories.Remove(userStory);
            }
        }

        class Project
        {
            private readonly List<UserStory> _userStories;
            private readonly List<Epic> _epics;
            private int _storyPoints;

            public Project()
            {
                _userStories = new List<UserStory>();
                _epics = new List<Epic>();
            }

            public int CalculateStoryPoints()
            {
                // Add story points from all the user stories
                foreach (var userStory in _userStories)
                {
                    _storyPoints += userStory.CalculateStoryPoints();
                }

                // Add story points from all the epics
                foreach (var epic in _epics)
                {
                    _storyPoints += epic.CalculateStoryPoints();
                }

                return _storyPoints;
            }

            public void AddUserStory(UserStory userStory)
            {
                _userStories.Add(userStory);
            }

            public void RemoveUserStory(UserStory userStory)
            {
                _userStories.Remove(userStory);
            }

            public void AddEpic(Epic epic)
            {
                _epics.Add(epic);
            }

            public void RemoveEpic(Epic epic)
            {
                _epics.Remove(epic);
            }
        }
    }
}
