using System;
using System.Collections.Generic;

namespace composite
{
    interface IScrumComponent
    {
        int CalculateStoryPoints();
    }

    class WithComposite
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
            epic1.AddComponent(us1);
            epic1.AddComponent(us2);

            var epic2 = new Epic();
            epic2.AddComponent(us3);
            epic2.AddComponent(us4);

            // Project
            var project = new Project();
            project.AddComponent(epic1);
            project.AddComponent(epic2);
            project.AddComponent(us5);
            project.AddComponent(us6);

            // Calculate total sum, it should be 34
            var result = project.CalculateStoryPoints();
            Console.WriteLine($"Total number of story points in a Project is {result}");
        }

        class UserStory : IScrumComponent
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

        class Epic : IScrumComponent
        {
            private readonly List<IScrumComponent> _components;
            private int _storyPoints;

            public Epic()
            {
                _components = new List<IScrumComponent>();
            }

            public int CalculateStoryPoints()
            {
                foreach (var component in _components)
                {
                    _storyPoints += component.CalculateStoryPoints();
                }

                return _storyPoints;
            }

            public void AddComponent(IScrumComponent component)
            {
                _components.Add(component);
            }

            public void RemoveComponent(IScrumComponent component)
            {
                _components.Remove(component);
            }
        }

        class Project
        {
            private readonly List<IScrumComponent> _components;
            private int _storyPoints;

            public Project()
            {
                _components = new List<IScrumComponent>();
            }

            public int CalculateStoryPoints()
            {
                // Add story points from all the user stories
                foreach (var component in _components)
                {
                    _storyPoints += component.CalculateStoryPoints();
                }

                return _storyPoints;
            }

            public void AddComponent(IScrumComponent component)
            {
                _components.Add(component);
            }

            public void RemoveComponent(IScrumComponent component)
            {
                _components.Remove(component);
            }
        }
    }
}