using Infrastructure.DB;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class RelationshipsTeacherSubjectRepository
    {
        private readonly CollegeDBContext _db;
        public RelationshipsTeacherSubjectRepository(CollegeDBContext db)
        {
            _db = db;
        }

        public RelationshipsTeacherSubject GetByID(int ID)
        {
            return _db.RelationshipsTeacherSubject.Where(r => r.ID == ID).FirstOrDefault();
        }

        public List<RelationshipsTeacherSubject> GetAll()
        {
            return _db.RelationshipsTeacherSubject.ToList();
        }

        public int Insert(RelationshipsTeacherSubject relationships)
        {
            _db.RelationshipsTeacherSubject.Add(relationships);
            return _db.SaveChanges();
        }

        public bool Delete(int ID)
        {
            var r = _db.RelationshipsTeacherSubject.Where(r => r.ID == ID).SingleOrDefault();

            if (r == null)
                return false;

            _db.RelationshipsTeacherSubject.Remove(r);

            _db.SaveChanges();

            return true;
        }

        public RelationshipsTeacherSubject Update(RelationshipsTeacherSubject relationships)
        {
            var r = _db.RelationshipsTeacherSubject.Where(r => r.ID == relationships.ID).SingleOrDefault();

            if (r == null)
                return null;

            r.SubjectID = relationships.SubjectID;
            r.TeacherID = relationships.TeacherID;

            _db.SaveChanges();

            return r;
        }
    }
}
