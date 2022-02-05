﻿using Api.Repositories;

namespace Api.UnitOfWorks
{
    public interface IUnitOfWork: IDisposable
    {
        AccountRepository AccountRepository { get; }
        ReportRepository ReportRepository { get; }
        RoleRepository RoleRepository { get; }
        GroupRepository GroupRepository { get; }
        ProjectRepository ProjectRepository { get; }
        CouncilEvaluationRepository CouncilEvaluationRepository { get; }    
        SubmitRepository SubmitRepository { get; }
        TeacherEvaluationRepository TeacherEvaluationRepository { get; }
        Task CompleteAsync();
    }
}
