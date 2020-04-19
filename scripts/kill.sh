kill $(ps aux | grep '[d]otnet bin/Debug/netcoreapp2.1/Blog.Web.dll' | awk '{print $2}')
echo "Kill Done"