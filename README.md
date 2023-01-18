# Develop DotNetCore Inside of a Container!

## Dev

1. Install Docker Desktop and make sure it's running
2. Install VS Code and install the `Dev Containers` extension
3. Clone this repo and open it in VS Code
4. Re-open the folder in a container via the command pallete
   - ctrl+shift+p -> Dev Containers: Reopen in Container

## Troubleshooting

### Extensions were not automatically installed

This is likely due to your network settings. If your machine uses man-in-the-middle software with a self-signed certificate (most corporations do), 
you will need to include a bundle certificate: .devcontainer/bundle_cert.pem 

### Git is complaining about 'unsafe' repositories

This is the same problem with self signed certificates. See the `#Extensions were not automatically installed` section above
