$working_branch = git branch --show-current
$new_branch = $working_branch + "_squashed"
git add .
git commit -m "U3DT Auto Commit Message: Squashing into new branch"

git switch main
git pull
git checkout -b $new_branch main
git merge --squash $working_branch
git branch -D $working_branch
git branch -m $working_branch
git add .
git commit -m "U3DT Auto Commit Message: Squashing Working Branch"
git push --set-upstream --force origin $working_branch