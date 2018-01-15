The following tasks should be completed before publishing a release. Track the progress of the release by copying and pasting the tasks below into an issue for the release.

#### Github and Project Planning

- [ ] Review and merge any outstanding pull requests.
- [ ] Review any oustanding issues assigned to this release milestone.
- [ ] Branch from `develop` to `rc-[version]`, ex: `rc-1.0.0`.
- [ ] Draft release with version in the format of `v1.3.0` targeting the 'master' branch. Standard release should be named using the format `Watson Developer Cloud .NET Standard SDK [version]`, ex: `Watson Developer Cloud .NET Standard SDK v1.3.0`.
 
#### Source Changes (in `rc` branch)

- [ ] Update `artifacts` in `appveyor.yml` if there are any new service abstractions.
- [ ] Update changelog.
- [ ] Update dependencies and nuget badge in readme files to updated version (Nuget badge is the first line of the readme, search for `dependencies` for the dependency version)
- [ ] Update `PROJECT_NUMBER` in `Doxyfile` to current version.
- [ ] Update `SDK_VERSION` in `src/IBM.WatsonDeveloperCloud/Constants.cs`
- [ ] Update version and dependencies in all `project.json` files (ignore `lock.json` files). I do this manually by searching the entire solution for the last version and changing to the current version in case some dependency has a version overlap.
- [ ] Clean and rebuild solution in Visual Studio. Run all tests. Warnings that the latest version cannot be found are expected.

#### Publish Release

- [ ] Create a pull request to merge `rc` branch to `master`. After all checks have passed, merge the PR.
- [ ] Publish release. This should tag release using format `v1.3.0`. This will trigger a build and update [documentation](https://watson-developer-cloud.github.io/dotnet-standard-sdk/). If the release build fails in AppVeyor, rebuild the commit using the `rebuild commit` button.
- [ ] Create a pull request to merge `rc` branch into the `development` branch.
- [ ] If it's a `major` or `breaking` release, on the `development` branch, revise `version` in `appveyor.yml` to the next version so builds in appveyor will start with the correct version.ect version.