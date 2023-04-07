git checkout --force main
$branch_list = git branch

foreach ($branch in $branch_list) {
    $branch = $branch.replace("*","")
    $branch = $branch.replace(" ","")
    if ($branch -ne "main") {
        git branch -D $branch
    }
}
git pull
git fetch
git remote prune origin