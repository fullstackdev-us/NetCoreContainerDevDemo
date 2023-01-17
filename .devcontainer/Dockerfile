FROM mcr.microsoft.com/devcontainers/dotnet:0-7.0

# Add your bundle_cert to the container certificate chain.
# This fixes problems certain CLI services have with self assigned certificates.
# If you are using this on a machine that has man-in-the-middle certs (you are in a large organization with good network security) you will need to do this
# https://github.com/microsoft/vscode-remote-release/issues/2987
COPY ./bundle_cert.pem /usr/local/share/ca-certificates/bundle_cert.crt
RUN update-ca-certificates