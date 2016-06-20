using System.Collections.Generic;

namespace StudyTest
{
    public class Station
    {
        public Station (char n)
        {
            name = n;
            trains = new List<Train>();
        }
        public char name;
        public List<Train> trains;
    }

    public class Train
    {
        public Train()
        {
            paths = new List<Path>();
        }
        public char name;
        public List<Path> paths;
    }

    public class Path
    {
        public Path(char n, Station s, Station e)
        {
            trainName = n;
            start = s;
            end = e;
        }
        public char trainName;
        public Station start;
        public Station end;
    }
}