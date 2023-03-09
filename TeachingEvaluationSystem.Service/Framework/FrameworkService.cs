using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TeachingEvaluationSystem.DB;
using TeachingEvaluationSystem.Service.Global;

namespace TeachingEvaluationSystem.Service.Framework
{
    public static class FrameworkService
    {
        public static IServiceCollection AddTES(this IServiceCollection services)
        {
            services.AddDbContext<TeachingEvaluationSystemDB>();
            services.AddSingleton<LoginService>();
            services.AddSingleton<UserService>();
            services.AddSingleton<RoleService>();
            services.AddSingleton<MenuService>();
            services.AddSingleton<ClassService>();
            services.AddSingleton<QuestionTypeService>();
            services.AddSingleton<QuestionBankService>();
            services.AddSingleton<UserClassesService>();
            services.AddSingleton<SubjectService>();
            services.AddSingleton<UserAnswerService>();
            services.AddSingleton<GlobalInfo>();
            return services;
        }
    }
}
