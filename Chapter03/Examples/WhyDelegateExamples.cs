using System;
using System.Collections.Generic;

namespace Chapter03Examples
{
    public class User
    {
        public string Surname { get; set; }
        public string LoginName { get; set; }
        public string Location { get; set; }

    }

    class WhyDelegateExamples
    {
        private List<User> _users = new List<User>
        {
            new User {LoginName = "DaveW", Surname = "Wright", Location = "London"},
            new User {LoginName = "BobM", Surname = "Monkhouse", Location = "Scotland"},
            new User {LoginName = "JamesR", Surname = "Raff", Location = "Norfolk"}
        };

        public void DoSearch()
        {
            var user1 = FindBySurname("Wright");
            var user2 = FindByLoginName("JamesR");
            var user3 = FindByLocation("Scotland");

            // Using delegates
            var user4 = Find(user => user.Surname == "Wright");
            var user5 = Find(user => user.LoginName == "JamesR");
            var user6 = Find(user => user.Location == "Scotland");
        }

        private User FindBySurname(string name)
        {
            foreach (var user in _users)
                if (user.Surname == name)
                    return user;

            return null;
        }

        private User FindByLoginName(string name)
        {
            foreach (var user in _users)
                if (user.LoginName == name)
                    return user;

            return null;
        }

        private User FindByLocation(string name)
        {
            foreach (var user in _users)
                if (user.Location == name)
                    return user;

            return null;
        }

        private delegate bool FindUser(User user);

        private User Find(FindUser predicate)
        {
            foreach (var user in _users)
                if (predicate(user))
                    return user;

            return null;
        }
    }


    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
    }

    public interface ITransform
    {
        Point Move(double height, double width);
    }

    public class RotateTransform : ITransform
    {

        public Point Move(double height, double width)
        {
            // do stuff
            return new Point();
        }
    }

    public class ZoomTransform : ITransform
    {
        public Point Move(double height, double width)
        {
            // do stuff
            return new Point();
        }
    }

    public class Transformer
    {
        public void Transform()
        {
            var rotatePoint = Calculate(new RotateTransform(), 100, 20);
            var zoomPoint = Calculate(new ZoomTransform(), 5, 5);


            // using delegates
            var rotatePoint1 = Calculate(Rotate, 100, 20);
            var zoomPoint1 = Calculate(Zoom, 5, 5);
        }

        private Point Calculate(ITransform transformer, double height, double width)
        {
            var point = transformer.Move(height, width);
            //do stuff to point
            return point;
        }

        // Delegates
        private delegate Point TransformPoint(double height, double width);

        private Point Calculate(TransformPoint transformer, double height, double width)
        {
            var point = transformer(height, width);
            //do stuff to point
            return point;
        }

        private Point Rotate(double height, double width)
        {
            return new Point();
        }

        private Point Zoom(double height, double width)
        {
            return new Point();
        }
    }
        
}