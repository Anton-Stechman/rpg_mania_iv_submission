$working_branch = git branch --show-current
$new_branch = $working_branch + "_squashed"
git add .
git commit -m "U3DT Auto Commit Message: Squashing into new branch"

git switch main
git pull
git checkout -b $new_branch main
git merge --squash $working_branch