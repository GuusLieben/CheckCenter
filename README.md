# CM - Check Center
## Avans Informatica 2.2
A single-page application built with:
- [ASP.NET Core](https://get.asp.net/) and [C#](https://msdn.microsoft.com/en-us/library/67ef8sbd.aspx) for cross-platform server-side code
- [Angular](https://angular.io/) and [TypeScript](http://www.typescriptlang.org/) for client-side code
- [Bootstrap](http://getbootstrap.com/) and [Aurora](https://www.cm.com/app/aurora-dls/introduction) for layout and styling

## Preview
![image](https://user-images.githubusercontent.com/10957963/111188268-2d44f200-85b5-11eb-824e-d09274e6f951.png)

## GitLab
### Branches
The default branch is _master_, which only accepts Merge Requests, and does not accept direct pushes.
The development branch is _development_, which only accepts Merge Requests, and does not accept direct pushes from developers.

There are several release branches, each follow the format _release-[year]w[week][dayOfWeekChar]_. e.g. The release for Monday 16th December 2019 (week 51, monday is the first day of the week) is _release-19w51a_.

Feature branches will be created during development, and follow the format _feature-[JiraId]-[featureKeyword]_. e.g. The design of the Identity database entities (JiraId : SERVER-35) is _feature-CLIENT35-IdDb_.

### CI/CD
Any merges to _development_ and _master_ will automatically trigger the Test pipeline. Merges to _development_ will also include codestyle tests.

### Deployment
Any merges to _release-*_ will trigger the [Artifact pipeline](https://docs.gitlab.com/ee/user/project/pipelines/job_artifacts.html), which delivers a packages version of the application to be used on a production server (during development this will be [cm.dockbox.org](http://cm.dockbox.org/)).

### TODO
#### High

- Comment post functioneel maken [Dylan]
-- Ook delete?

###### Available (High)
- Repository testen 
- Actionlogs by user
- Deployment diagram
- Repository (Unit) testen

- Bewijslast adhv beoordelingsmodel

#### Medium
- Login invalid duidelijker maken
- Readonly/CUD omgeving :
-- Buiten netwerk CM melding geven : read-only
--: CUD actions disabled
- Login loading icon
