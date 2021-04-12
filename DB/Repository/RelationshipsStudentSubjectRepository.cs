using Infrastructure.DB;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class RelationshipsStudentSubjectRepository
    {
        private readonly CollegeDBContext _db;
        public RelationshipsStudentSubjectRepository(CollegeDBContext db)
        {
            _db = db;
        }

        public RelationshipsStudentSubject GetByID(int ID)
        {
            return _db.RelationshipsStudentSubject.Where(r => r.ID == ID).FirstOrDefault();
        }

        public List<RelationshipsStudentSubject> GetAll()
        {
            return _db.RelationshipsStudentSubject.ToList();
        }

        public int Insert(RelationshipsStudentSubject relationships)
        {
            _db.RelationshipsStudentSubject.Add(relationships);
            return _db.SaveChanges();
        }

        public bool Delete(int ID)
        {
            var r = _db.RelationshipsStudentSubject.Where(r => r.ID == ID).SingleOrDefault();

            if (r == null)
                return false;

            _db.RelationshipsStudentSubject.Remove(r);

            _db.SaveChanges();

            return true;
        }

        public RelationshipsStudentSubject Update(RelationshipsStudentSubject relationships)
        {
            var r = _db.RelationshipsStudentSubject.Where(r => r.ID == relationships.ID).SingleOrDefault();

            if (r == null)
                return null;

            r.SubjectID = relationships.SubjectID;
            r.StudentID = relationships.StudentID;

            _db.SaveChanges();

            return r;
        }
    }
}
